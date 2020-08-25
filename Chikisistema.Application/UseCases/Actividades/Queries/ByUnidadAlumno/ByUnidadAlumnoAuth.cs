using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.ByUnidadAlumno
{
    public class ByUnidadAlumnoAuth : IAlumnoRequest<ByUnidadAlumnoQuery, IEnumerable<ByUnidadAlumnoResponse>>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public ByUnidadAlumnoAuth(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(ByUnidadAlumnoQuery request, ValidationResult validationResult)
        {
            var alumnoCursa = await db
                    .Unidad
                    .Where(el => el.Id == request.IdUnidad)
                    .SelectMany(el => el.Curso.AlumnoCurso)
                    .AnyAsync(el => el.IdAlumno == currentUser.UserId);

            if (!alumnoCursa)
            {
                throw (new NotAuthorizedException("No estas inscrito al curso"));
            }
        }
    }
}