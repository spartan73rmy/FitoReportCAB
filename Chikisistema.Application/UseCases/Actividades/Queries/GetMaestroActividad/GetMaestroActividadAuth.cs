using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetMaestroActividad
{
    public class GetMaestroActividadAuth : IMaestroRequest<GetMaestroActividadQuery, GetMaestroActividadResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public GetMaestroActividadAuth(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(GetMaestroActividadQuery request, ValidationResult validationResult)
        {
            var curso = await db
                .ActividadCurso
                .Where(el => el.Id == request.IdActividad)
                .Select(el => el.Unidad.Curso)
                .SingleOrDefaultAsync();

            if (curso == null)
            {
                throw new NotFoundException(nameof(request.IdActividad), request.IdActividad);
            }

            if (curso.IdMaestro != currentUser.UserId)
            {
                validationResult.Errors.Add("No es tu curso maestro");
            }
        }
    }
}