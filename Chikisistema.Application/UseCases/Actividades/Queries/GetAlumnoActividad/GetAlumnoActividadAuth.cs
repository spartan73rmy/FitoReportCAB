using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAlumnoActividad
{
    public class GetAlumnoActividadAuth : IAlumnoRequest<GetAlumnoActividadQuery, GetAlumnoActividadResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public GetAlumnoActividadAuth(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(GetAlumnoActividadQuery request, ValidationResult validationResult)
        {
            bool pertence = await db
                .ActividadCurso
                .Where(el => el.Id == request.IdActividad)
                .SelectMany(el => el.Unidad.Curso.AlumnoCurso)
                .AnyAsync(el => el.IdAlumno == currentUser.UserId);

            if (!pertence)
            {
                validationResult.Errors.Add("No estas inscrito al curso");
            }
        }
    }
}