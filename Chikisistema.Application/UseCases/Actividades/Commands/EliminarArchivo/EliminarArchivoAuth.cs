using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.EliminarArchivo
{
    public class EliminarArchivoAuth : IMaestroRequest<EliminarArchivoCommand, EliminarArchivoResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public EliminarArchivoAuth(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(EliminarArchivoCommand request, ValidationResult validationResult)
        {

            var maestroActividad = await db
                .ArchivoUsuario
                .Where(el => el.Hash == request.Archivo)
                .SelectMany(el => el.MaterialApoyo)
                .Where(el => el.IdActividad == request.IdActividad)
                .Select(el => el.Actividad.Unidad.Curso)
                .SingleOrDefaultAsync();

            if (maestroActividad == null) throw new NotFoundException(nameof(request.Archivo), request.Archivo);

            if (maestroActividad.IdMaestro != currentUser.UserId)
            {
                validationResult.Errors.Add("No es tu curso maestro");
            }
        }
    }
}