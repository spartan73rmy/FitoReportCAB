using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.EditarActividadAlumno
{
    public class EditarActividadAlumnoAuth : IAlumnoRequest<EditarActividadAlumnoCommand, EditarActividadAlumnoResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public EditarActividadAlumnoAuth(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(EditarActividadAlumnoCommand request, ValidationResult validationResult)
        {
            var actividadUsuario = await db
                .UsuarioActividad
                .SingleOrDefaultAsync(el => el.IdActividad == request.IdActividad && el.IdUsuario == currentUser.UserId);

            if (actividadUsuario == null) throw new NotFoundException(nameof(UsuarioActividad), request.IdActividad);

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