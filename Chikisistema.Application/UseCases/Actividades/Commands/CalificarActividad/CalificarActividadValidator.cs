using Chikisistema.Application.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.CalificarActividad
{
    public class CalificarActividadValidator : AbstractValidator<CalificarActividadCommand>
    {
        private readonly IChikisistemaDbContext db;

        public CalificarActividadValidator(IChikisistemaDbContext db)
        {
            this.db = db;
            RuleFor(el => el.IdActividad).GreaterThan(0);
            RuleFor(el => el.IdAlumno).GreaterThan(0);
            RuleFor(el => el.Calificacion).GreaterThan(0);
        }

        public override async Task<FluentValidation.Results.ValidationResult> ValidateAsync(ValidationContext<CalificarActividadCommand> context, CancellationToken cancellation = default)
        {
            var result = new FluentValidation.Results.ValidationResult();
            var entity = context.InstanceToValidate;

            var actividadCurso = await db
                .ActividadCurso
                .SingleOrDefaultAsync(el => el.Id == entity.IdActividad);

            if (!actividadCurso.BloquearEnvios)
            {
                result.Errors.Add(new ValidationFailure(nameof(actividadCurso.BloquearEnvios), "Debe bloquear los envios para calificar"));
            }

            if (entity.Calificacion > actividadCurso.Valor)
            {
                result.Errors.Add(new ValidationFailure(nameof(entity.Calificacion), "La calificacion debe ser menor o igual que: " + actividadCurso.Valor));
            }

            return result;
        }
    }
}