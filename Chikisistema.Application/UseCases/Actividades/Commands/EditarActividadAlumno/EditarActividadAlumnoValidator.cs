using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.EditarActividadAlumno
{
    public class EditarActividadAlumnoValidator : AbstractValidator<EditarActividadAlumnoCommand>
    {
        private readonly IChikisistemaDbContext db;

        public EditarActividadAlumnoValidator(IChikisistemaDbContext db)
        {
            this.db = db;
            RuleFor(el => el.Archivo).NotEmpty().When(el => el.Contenido == null);
            RuleFor(el => el.Contenido).NotEmpty().When(el => el.Archivo == null);
            RuleFor(el => el.IdActividad).NotEmpty().GreaterThan(0);
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<EditarActividadAlumnoCommand> context, CancellationToken cancellation = default)
        {
            var request = context.InstanceToValidate;
            var result = new ValidationResult();

            var actividadBloqueoEnvios = await db
                .ActividadCurso
                .Where(el => el.Id == request.IdActividad)
                .Select(el => el.BloquearEnvios)
                .SingleOrDefaultAsync();

            if (actividadBloqueoEnvios)
            {
                throw new BadRequestException("Se han bloqueado los envios");
            }
            return result;
        }
    }
}