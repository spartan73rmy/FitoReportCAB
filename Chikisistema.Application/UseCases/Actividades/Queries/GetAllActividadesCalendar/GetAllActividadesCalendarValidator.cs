using FluentValidation;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesCalendar
{
    public class GetAllActividadesCalendarValidator : AbstractValidator<GetAllActividadesCalendarQuery>
    {
        public GetAllActividadesCalendarValidator()
        {
            RuleFor(el => el.FirstDate).NotEmpty();
            RuleFor(el => el.SecondDate).NotEmpty().GreaterThan(el => el.FirstDate);
        }
    }
}