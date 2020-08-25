using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.AgregarImagenPerfil
{
    public class AgregarImagenPerfilHandler : IRequestHandler<AgregarImagenPerfilCommand, AgregarImagenPerfilResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public AgregarImagenPerfilHandler(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task<AgregarImagenPerfilResponse> Handle(AgregarImagenPerfilCommand request, CancellationToken cancellationToken)
        {
            var usuario = await db
                .Usuario
                .SingleOrDefaultAsync(el => el.Id == currentUser.UserId);

            usuario.ImagenPerfil = request.Imagen;
            await db.SaveChangesAsync(cancellationToken);
            return new AgregarImagenPerfilResponse
            {

            };
        }
    }
}