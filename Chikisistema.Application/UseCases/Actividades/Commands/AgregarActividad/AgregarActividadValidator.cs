using Chikisistema.Common;
using FluentValidation;

namespace Chikisistema.Application.UseCases.Actividades.Commands.AgregarActividad
{
    public class AgregarActividadValidator : AbstractValidator<AgregarActividadCommand>
    {
        public AgregarActividadValidator(IDateTime dateTime)
        {
            RuleFor(el => el.IdUnidad).NotEmpty().GreaterThan(0);
            RuleFor(el => el.IdTipoActividad).NotEmpty().GreaterThan(0);
            RuleFor(el => el.Titulo).NotEmpty();
            RuleFor(el => el.Valor).NotEmpty().GreaterThan(0);
            RuleFor(el => el.Contenido).NotEmpty();
            RuleFor(el => el.FechaLimite).NotEmpty().GreaterThan(el => dateTime.Now);
            RuleFor(el => el.FechaActivacion).LessThan(el => el.FechaLimite).When(el => el.FechaActivacion.HasValue);
        }
    }
}