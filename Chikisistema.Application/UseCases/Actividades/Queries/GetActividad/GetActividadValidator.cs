using FluentValidation;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetActividad
{
    public class GetActividadValidator : AbstractValidator<GetActividadQuery>
    {
        public GetActividadValidator()
        {
            RuleFor(el => el.IdActividad).GreaterThan(0).NotEmpty();
        }
    }
}