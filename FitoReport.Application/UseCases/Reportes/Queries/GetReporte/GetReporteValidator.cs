using FluentValidation;

namespace FitoReport.Application.UseCases.Reportes.Queries.GetReporte
{
    public class GetReporteValidator : AbstractValidator<GetReporteQuery>
    {
        public GetReporteValidator()
        {
            RuleFor(el => el.IdReporte).GreaterThan(0).NotEmpty();
        }
    }
}