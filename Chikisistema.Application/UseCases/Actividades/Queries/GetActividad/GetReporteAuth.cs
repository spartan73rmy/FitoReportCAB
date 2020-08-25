using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetActividad
{
    public class GetReporteAuth : IAuthenticatedRequest<GetReporteQuery, GetReporteResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public GetReporteAuth(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(GetReporteQuery request, ValidationResult validationResult)
        {
            //var curso = await db
            //    .ActividadCurso
            //    .Select(el => new
            //    {
            //        el.Id,
            //        el.Unidad.IdCurso,
            //        el.Unidad.Curso.IdMaestro
            //    }).SingleOrDefaultAsync(el => el.Id == request.IdActividad);

            //if (curso == null) throw new NotFoundException(nameof(ActividadCurso), request.IdActividad);

            //if (currentUser.TipoUsuario == Domain.Enums.TiposUsuario.Alumno)
            //{
            //    bool pertence = await db.AlumnoCurso.AnyAsync(el => el.IdCurso == curso.IdCurso && el.IdAlumno == currentUser.UserId);
            //    if (!pertence)
            //    {
            //        validationResult.Errors.Add("No estas inscrito al curso");
            //    }
            //}
            //else
            //{
            //    if (currentUser.UserId != curso.IdMaestro)
            //    {
            //        validationResult.Errors.Add("No es tu curso maestro");
            //    }
            //}
        }
    }
}