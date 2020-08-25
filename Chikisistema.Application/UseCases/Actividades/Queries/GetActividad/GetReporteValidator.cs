using FluentValidation;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetActividad
{
    public class GetReporteValidator : AbstractValidator<GetReporteQuery>
    {
        public GetReporteValidator()
        {
            //RuleFor(el => el.IdActividad).GreaterThan(0).NotEmpty();
        }
    }
}