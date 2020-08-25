using FluentValidation;

namespace Chikisistema.Application.UseCases.Actividades.Commands.BloquearActividad
{
    public class BloquearActividadValidator : AbstractValidator<BloquearActividadCommand>
    {
        public BloquearActividadValidator()
        {
            RuleFor(el => el.IdActividad).NotEmpty().GreaterThan(0);
        }
    }
}