using FluentValidation;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesCalendarMaestro
{
    public class GetAllActividadesCalendarMaestroValidator : AbstractValidator<GetAllActividadesCalendarMaestroQuery>
    {
        public GetAllActividadesCalendarMaestroValidator()
        {
            RuleFor(el => el.From).NotEmpty();
            RuleFor(el => el.To).NotEmpty().GreaterThan(el => el.From);
        }
    }
}