using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetActividadesPendientes
{
    public class GetActividadesPendientesAuth : IAlumnoRequest<GetActividadesPendientesQuery, GetActividadesPendientesResponse>
    {
        private readonly IUserAccessor currentUser;
        private readonly IChikisistemaDbContext db;

        public GetActividadesPendientesAuth(IUserAccessor currentUser, IChikisistemaDbContext db)
        {
            this.currentUser = currentUser;
            this.db = db;
        }

        public async Task Validate(GetActividadesPendientesQuery request, ValidationResult validationResult)
        {
            bool pertence = await db
                .AlumnoCurso
                .AnyAsync(el => el.IdCurso == request.IdCurso && el.IdAlumno == currentUser.UserId);

            if (!pertence)
            {
                validationResult.Errors.Add("No estas inscrito al curso");
            }
        }
    }
}