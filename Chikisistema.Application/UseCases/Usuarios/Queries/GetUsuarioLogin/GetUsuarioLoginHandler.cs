﻿using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Chikisistema.Common;
using Chikisistema.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Usuarios.Queries.GetUsuarioLogin
{
    public class GetUsuarioLoginHandler : IRequestHandler<GetUsuarioLoginQuery, GetUsuarioLoginResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IDateTime dateTime;
        private readonly IRandomGenerator randomGenerator;

        public GetUsuarioLoginHandler(IChikisistemaDbContext db, IDateTime dateTime, IRandomGenerator randomGenerator)
        {
            this.db = db;
            this.dateTime = dateTime;
            this.randomGenerator = randomGenerator;
        }

        public async Task<GetUsuarioLoginResponse> Handle(GetUsuarioLoginQuery request, CancellationToken cancellationToken)
        {
            var entity = await db
                .Usuario
                .SingleOrDefaultAsync(el => el.NombreUsuario == request.NombreUsuario || el.Email == request.NombreUsuario);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), request.NombreUsuario);
            }

            if (PasswordStorage.VerifyPassword(request.Password, entity.HashedPassword))
            {
                if (!entity.Confirmado)
                {
                    throw new ForbiddenException("Email no confirmado");
                }

                string randomToken = randomGenerator.SecureRandomString(32);

                db.UsuarioToken.Add(new UsuarioToken
                {
                    IdUsuario = entity.Id,
                    RefreshToken = randomToken
                });
                entity.AccessFailedCount = 0;

                await db.SaveChangesAsync(cancellationToken);

                return new GetUsuarioLoginResponse
                {
                    Email = entity.Email,
                    NombreUsuario = entity.NombreUsuario,
                    IdUsuario = entity.Id,
                    TipoUsuario = entity.TipoUsuario,
                    RefreshToken = randomToken
                };
            }
            else
            {
                entity.AccessFailedCount++;
                if (entity.AccessFailedCount >= 5)
                {
                    entity.LockoutEnd = dateTime.Now.AddMinutes(1);
                }
                await db.SaveChangesAsync(cancellationToken);

                throw new NotFoundException(nameof(Usuario), request.NombreUsuario);
            }
        }
    }
}