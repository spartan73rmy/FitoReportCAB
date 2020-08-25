using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.AgregarArchivo
{
    public class AgregarArchivoAuth : IMaestroRequest<AgregarArchivoCommand, AgregarArchivoResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public AgregarArchivoAuth(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(AgregarArchivoCommand request, ValidationResult validationResult)
        {
            int autorActividad = await db
               .ActividadCurso
               .Where(el => el.Id == request.IdActividad)
               .Select(el => el.Unidad.Curso.IdMaestro)
               .SingleOrDefaultAsync();

            if (autorActividad != currentUser.UserId)
            {
                validationResult.Errors.Add("No creaste la actividad");
            }
        }
    }
}