using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.SubirArchivoAlumno
{
    public class SubirActividadAlumnoValidator : AbstractValidator<SubirActividadAlumnoCommand>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public SubirActividadAlumnoValidator(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            RuleFor(el => el.Archivo).NotEmpty().When(el => el.Contenido == null);
            RuleFor(el => el.Contenido).NotEmpty().When(el => el.Archivo == null);
            RuleFor(el => el.IdActividad).NotEmpty().GreaterThan(0);
            this.db = db;
            this.currentUser = currentUser;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<SubirActividadAlumnoCommand> context, CancellationToken cancellation = default)
        {
            var request = context.InstanceToValidate;
            var usuarioSubioPreviamenteActividad = await db
                .UsuarioActividad
                .AnyAsync(el => el.IdUsuario == currentUser.UserId && request.IdActividad == el.IdActividad);
            
            var actividadBloqueoEnvios = await db.ActividadCurso.Where(el => el.Id == request.IdActividad).Select(el => el.BloquearEnvios).SingleOrDefaultAsync();

            if (usuarioSubioPreviamenteActividad)
            {
                throw new BadRequestException("Ya subiste previamente la actividad");
            }

            if (actividadBloqueoEnvios)
            {
                throw new BadRequestException("Se han bloqueado los envios");
            }

            return new ValidationResult();
        }
    }
}