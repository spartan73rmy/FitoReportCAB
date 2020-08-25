using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.BloquearActividad
{
    public class BloquearActividadAuth : IMaestroRequest<BloquearActividadCommand, BloquearActividadResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public BloquearActividadAuth(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(BloquearActividadCommand request, ValidationResult validationResult)
        {
            var unidad = await db
                    .ActividadCurso
                    .Where(el => el.Id == request.IdActividad)
                    .Select(el => new { el.Unidad.Curso.IdMaestro })
                    .SingleOrDefaultAsync();

            if (unidad.IdMaestro != currentUser.UserId)
            {
                validationResult.Errors.Add("Maestro No Autorizado");
            }
        }
    }
}