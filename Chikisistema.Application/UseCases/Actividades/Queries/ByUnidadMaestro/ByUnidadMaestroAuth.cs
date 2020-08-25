using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.ByUnidadMaestro
{
    public class ByUnidadMaestroAuth : IMaestroRequest<ByUnidadMaestroQuery, IEnumerable<ByUnidadMaestroResponse>>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public ByUnidadMaestroAuth(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(ByUnidadMaestroQuery request, ValidationResult validationResult)
        {
            var curso = await db
                .Unidad
                .Where(el => el.Id == request.IdUnidad)
                .Select(el => new { el.IdCurso, el.Curso.IdMaestro })
                .SingleOrDefaultAsync();

            if (curso == null)
            {
                throw new NotFoundException(nameof(Unidad), request.IdUnidad);
            }

            if (curso.IdMaestro != currentUser.UserId)
            {
                validationResult.Errors.Add("Error, no es tu curso maestro");
            }
        }
    }
}