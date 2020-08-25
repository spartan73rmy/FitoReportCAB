using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAlumnosByActividad
{
    public class GetAlumnosByActividadValidator : AbstractValidator<GetAlumnosByActividadQuery>
    {
        private readonly IChikisistemaDbContext db;

        public GetAlumnosByActividadValidator(IChikisistemaDbContext db)
        {
            RuleFor(el => el.IdActividad).GreaterThan(0).NotEmpty();
            this.db = db;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<GetAlumnosByActividadQuery> context, CancellationToken cancellation = default)
        {
            ValidationResult result = new ValidationResult();
            var request = context.InstanceToValidate;
            var actividadCurso = await db.ActividadCurso.FindAsync(request.IdActividad);

            if (actividadCurso == null)
                throw new NotFoundException(nameof(ActividadCurso), request.IdActividad);

            bool unidadExiste = await db.Unidad.AnyAsync(el => el.Id == actividadCurso.IdUnidad);

            if (!unidadExiste)
                throw new NotFoundException(nameof(Unidad), actividadCurso.IdUnidad);

            return result;
        }
    }
}