using Chikisistema.Application.Interfaces;
using Chikisistema.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.EditarActividadAlumno
{
    public class EditarActividadAlumnoHandler : IRequestHandler<EditarActividadAlumnoCommand, EditarActividadAlumnoResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IDateTime datetime;
        private readonly IUserAccessor currentUser;

        public EditarActividadAlumnoHandler(IChikisistemaDbContext db, IDateTime datetime, IUserAccessor currentUser)
        {
            this.db = db;
            this.datetime = datetime;
            this.currentUser = currentUser;
        }

        public async Task<EditarActividadAlumnoResponse> Handle(EditarActividadAlumnoCommand request, CancellationToken cancellationToken)
        {
            var usuarioActividad = await db
                .UsuarioActividad
                .SingleOrDefaultAsync(el => el.IdActividad == request.IdActividad && el.IdUsuario == currentUser.UserId);

            var archivo = await db
                .ArchivoUsuario
                .SingleOrDefaultAsync(el => el.Hash == request.Archivo);

            usuarioActividad.Contenido = request.Contenido;
            usuarioActividad.IdArchivo = archivo?.Id;
            usuarioActividad.FechaEntrega = datetime.Now;

            await db.SaveChangesAsync(cancellationToken);
            return new EditarActividadAlumnoResponse
            {
                Id = usuarioActividad.Id
            };
        }
    }
}