using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.ConfirmarEmail
{
    public class ConfirmarEmailHandler : IRequestHandler<ConfirmarEmailCommand, ConfirmarEmailResponse>
    {
        private readonly IChikisistemaDbContext db;

        public ConfirmarEmailHandler(IChikisistemaDbContext db)
        {
            this.db = db;
        }

        public async Task<ConfirmarEmailResponse> Handle(ConfirmarEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await db
                .Usuario
                .SingleOrDefaultAsync(el => el.TokenConfirmacion == request.Token, cancellationToken);

            if (user == null) throw new NotFoundException(nameof(Usuario), request.Token);

            if (user.Confirmado)
            {
                throw new BadRequestException("El usuario se confirmo previamente");
            }
       

            user.Confirmado = true;
            user.TokenConfirmacion = null;

            await db.SaveChangesAsync(cancellationToken);

            return new ConfirmarEmailResponse
            {
            };
        }
    }
}