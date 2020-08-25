using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Chikisistema.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.RecuperaPassword
{
    public class RecuperaPasswordHandler : IRequestHandler<RecuperaPasswordCommand, RecuperaPasswordResponse>
    {
        private readonly IChikisistemaDbContext db;

        public RecuperaPasswordHandler(IChikisistemaDbContext db)
        {
            this.db = db;
        }

        public async Task<RecuperaPasswordResponse> Handle(RecuperaPasswordCommand request, CancellationToken cancellationToken)
        {
            var usuario = await db
                .Usuario
                .SingleOrDefaultAsync(el => el.TokenConfirmacion == request.Token);

            if (usuario == null) throw new NotFoundException(nameof(Usuario), new { });

            string pass = PasswordStorage.CreateHash(request.Password);

            usuario.HashedPassword = pass;
            usuario.TokenConfirmacion = null;

            await db.SaveChangesAsync(cancellationToken);

            return new RecuperaPasswordResponse();
        }
    }
}