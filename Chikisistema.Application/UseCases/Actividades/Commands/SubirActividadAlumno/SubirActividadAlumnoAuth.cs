using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.SubirArchivoAlumno
{
    public class SubirActividadAlumnoAuth : IAlumnoRequest<SubirActividadAlumnoCommand, SubirActividadAlumnoResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public SubirActividadAlumnoAuth(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(SubirActividadAlumnoCommand request, ValidationResult validationResult)
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

            if (request.Archivo != null)
            {
                bool archivoPertenece = await db
                    .ArchivoUsuario
                    .AnyAsync(el => el.Hash == request.Archivo && el.IdUsuario == currentUser.UserId);
                if (!archivoPertenece)
                {
                    validationResult.Errors.Add("El archivo no es valido");
                }
            }
        }
    }
}