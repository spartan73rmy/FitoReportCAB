using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.CalificarActividad
{
    public class CalificarActividadAuth : IMaestroRequest<CalificarActividadCommand, CalificarActividadResponse>
    {
        private readonly IUserAccessor currentUser;
        private readonly IChikisistemaDbContext db;

        public CalificarActividadAuth(IUserAccessor currentUser, IChikisistemaDbContext db)
        {
            this.currentUser = currentUser;
            this.db = db;
        }

        public async Task Validate(CalificarActividadCommand request, ValidationResult validationResult)
        {
            var usuarioActividad = await db
                .UsuarioActividad
                .Where(el => el.IdUsuario == request.IdAlumno && el.IdActividad == request.IdActividad)
                .Select(el => new { el.ActividadCurso.Unidad.Curso.IdMaestro })
                .SingleOrDefaultAsync();

            if (usuarioActividad == null) throw new NotFoundException(nameof(UsuarioActividad), request);

            if (usuarioActividad.IdMaestro != currentUser.UserId)
            {
                validationResult.Errors.Add("Maestro No Autorizado");
            }
        }
    }
}