using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Chikisistema.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.ModificarPassword
{
    public class ModificarPasswordHandler : IRequestHandler<ModificarPasswordCommand, ModificarPasswordResponse>
    {
        private readonly IFitoReportDbContext db;
        private readonly IUserAccessor currentUser;

        public ModificarPasswordHandler(IFitoReportDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task<ModificarPasswordResponse> Handle(ModificarPasswordCommand request, CancellationToken cancellationToken)
        {
            var entity = await db
                .Usuario
                .SingleOrDefaultAsync(el => el.Id == currentUser.UserId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), currentUser.UserId);
            }

            if (PasswordStorage.VerifyPassword(request.PasswordActual, entity.HashedPassword))
            {
                string pass = PasswordStorage.CreateHash(request.PasswordNuevo);

                entity.HashedPassword = pass;

                var tokens = await db
                    .UsuarioToken
                    .Where(el => el.IdUsuario == currentUser.UserId).
                    ToListAsync();

                db.UsuarioToken.RemoveRange(tokens);

                await db.SaveChangesAsync(cancellationToken);

                return new ModificarPasswordResponse
                {
                    Email = entity.Email
                };
            }
            else
            {
                throw new BadRequestException("La contraseña es Incorrecta");
            }
        }
    }
}