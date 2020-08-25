using FluentValidation;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAlumnoActividad
{
    public class GetAlumnoActividadValidator : AbstractValidator<GetAlumnoActividadQuery>
    {
        public GetAlumnoActividadValidator()
        {
            RuleFor(el => el.IdActividad).GreaterThan(0);
        }
    }
}