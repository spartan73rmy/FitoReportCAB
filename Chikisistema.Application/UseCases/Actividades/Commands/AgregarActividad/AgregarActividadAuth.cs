using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.AgregarActividad
{
    public class AgregarActividadAuth : IMaestroRequest<AgregarActividadCommand, AgregarActividadResponse>
    {
        private readonly IUserAccessor currentUser;
        private readonly IChikisistemaDbContext db;

        public AgregarActividadAuth(IUserAccessor currentUser, IChikisistemaDbContext db)
        {
            this.currentUser = currentUser;
            this.db = db;
        }

        public async Task Validate(AgregarActividadCommand request, ValidationResult validationResult)
        {
            var unidad = await db
                    .Unidad
                    .Select(el => new { el.Curso.IdMaestro, el.Id })
                    .SingleOrDefaultAsync(el => el.Id == request.IdUnidad);

            if (unidad.IdMaestro != currentUser.UserId)
            {
                validationResult.Errors.Add("Maestro No Autorizado");
            }
        }
    }
}