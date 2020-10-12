﻿using FitoReport.Application.Exceptions;
using FitoReport.Application.Interfaces;
using FitoReport.Application.Security;
using FitoReport.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.Infraestructure
{
    public class RequestAuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IList<IAuthenticatedRequest<TRequest, TResponse>> _rules;
        private readonly IUserAccessor userAccessor;
        private readonly ILogger<RequestAuthorizationBehaviour<TRequest, TResponse>> logger;
        private readonly Stopwatch timer;
        public RequestAuthorizationBehaviour(IEnumerable<IAuthenticatedRequest<TRequest, TResponse>> rules, IUserAccessor userAccessor, ILogger<RequestAuthorizationBehaviour<TRequest, TResponse>> logger)
        {
            _rules = rules.ToList();
            this.userAccessor = userAccessor;
            this.logger = logger;
            this.timer = new Stopwatch();
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            timer.Start();
            // Usuario no es publico y no esta autenticado y existen reglas
            if(userAccessor.TipoUsuario!=TiposUsuario.Publico)
                if (!userAccessor.IsAuthenticated && _rules.Count > 0)
                    throw new NotAuthorizedException("No autorizado");

            List<string> failures = new List<string>();
            foreach (var rule in _rules)
            {
                switch (rule)
                {
                    case IAdminRequest<TRequest, TResponse> _:
                        if (userAccessor.TipoUsuario != TiposUsuario.Admin)
                            failures.Add("No tienes permisos");
                        break;
                    case IUserRequest<TRequest, TResponse> _:
                        if (userAccessor.TipoUsuario != TiposUsuario.User)
                            failures.Add("No tienes permisos");
                        break;
                    case IProductorRequest<TRequest, TResponse> _:
                        if (userAccessor.TipoUsuario != TiposUsuario.Productor)
                            failures.Add("No tienes permisos");
                        break;
                    case INotAuth<TRequest, TResponse> _:
                        if (userAccessor.TipoUsuario != TiposUsuario.Publico)
                            failures.Add("No tienes permisos");
                        break;
                }

                if (failures.Count == 0)
                {
                    var validationResult = new ValidationResult();
                    await rule.Validate(request, validationResult);
                    failures.AddRange(validationResult.Errors.Where(error => error != null));
                }
                else break;
            }

            if (failures.Count != 0)
            {
                throw new NotAuthorizedException(failures);
            }
            timer.Stop();
            logger.LogInformation("Authorization behaviour took {ElapsedMilliseconds}ms", timer.ElapsedMilliseconds);
            return await next();
        }
    }
}
