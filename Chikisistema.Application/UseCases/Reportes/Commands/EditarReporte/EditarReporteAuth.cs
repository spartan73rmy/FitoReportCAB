using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Reportes.Commands.EditarReporte
{
    public class EditarReporteAuth : IAuthenticatedRequest<EditarReporteCommand, EditarReporteResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public EditarReporteAuth(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(EditarReporteCommand request, ValidationResult validationResult)
        {
            //var unidad = await db
            //        .ActividadCurso
            //        .Where(el => el.Id == request.IdActividad)
            //        .Select(el => new { el.Unidad.Curso.IdMaestro, el.BloquearEnvios })
            //        .SingleOrDefaultAsync();

            //if (unidad.IdMaestro != currentUser.UserId)
            //{
            //    validationResult.Errors.Add("Maestro No Autorizado");
            //}
        }
    }
}