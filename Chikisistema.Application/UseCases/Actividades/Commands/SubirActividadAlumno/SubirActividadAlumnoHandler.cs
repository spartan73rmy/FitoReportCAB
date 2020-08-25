using Chikisistema.Application.Interfaces;
using Chikisistema.Common;
using Chikisistema.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.SubirArchivoAlumno
{
    public class SubirActividadAlumnoHandler : IRequestHandler<SubirActividadAlumnoCommand, SubirActividadAlumnoResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;
        private readonly IDateTime dateTime;

        public SubirActividadAlumnoHandler(IChikisistemaDbContext db, IUserAccessor currentUser, IDateTime dateTime)
        {
            this.db = db;
            this.currentUser = currentUser;
            this.dateTime = dateTime;
        }

        public async Task<SubirActividadAlumnoResponse> Handle(SubirActividadAlumnoCommand request, CancellationToken cancellationToken)
        {
            var archivo = await db
                .ArchivoUsuario
                .SingleOrDefaultAsync(el => el.Hash == request.Archivo);

            var usuarioActividad = new UsuarioActividad
            {
                IdUsuario = currentUser.UserId,
                IdActividad = request.IdActividad,
                Contenido = request.Contenido,
                IdArchivo = archivo?.Id,
                FechaEntrega = dateTime.Now
            };

            db.UsuarioActividad.Add(usuarioActividad);

            await db.SaveChangesAsync(cancellationToken);

            return new SubirActividadAlumnoResponse
            {
                Id = usuarioActividad.Id
            };
        }
    }
}