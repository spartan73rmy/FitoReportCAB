using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAlumnosByActividad
{
    public class GetAlumnosByActividadAuth : IMaestroRequest<GetAlumnosByActividadQuery, GetAlumnosByActividadResponse>
    {
        private readonly IUserAccessor currentUser;
        private readonly IChikisistemaDbContext db;

        public GetAlumnosByActividadAuth(IUserAccessor currentUser, IChikisistemaDbContext db)
        {
            this.currentUser = currentUser;
            this.db = db;
        }

        public async Task Validate(GetAlumnosByActividadQuery request, ValidationResult validationResult)
        {
            var actividad = await db.ActividadCurso.FindAsync(request.IdActividad);

            if (actividad == null)
                throw new NotFoundException(nameof(ActividadCurso), request.IdActividad);

            var unidad = await db
                .Unidad
                .Select(el => new { el.Curso.IdMaestro, el.Id })
                .SingleOrDefaultAsync(el => el.Id == actividad.IdUnidad);

            if (unidad == null) throw new NotFoundException(nameof(request.IdActividad), request.IdActividad);

            if (unidad.IdMaestro != currentUser.UserId)
            {
                validationResult.Errors.Add("Maestro No Autorizado");
            }
        }
    }
}