using FluentValidation;

namespace Chikisistema.Application.UseCases.Reportes.Queries.GetReporte
{
    public class GetReporteValidator : AbstractValidator<GetReporteQuery>
    {
        public GetReporteValidator()
        {
            //RuleFor(el => el.IdActividad).GreaterThan(0).NotEmpty();
        }
    }
}