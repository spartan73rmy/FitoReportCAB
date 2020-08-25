using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.ByUnidadAlumno
{
    public class ByUnidadAlumnoValidator : AbstractValidator<ByUnidadAlumnoQuery>
    {
        private readonly IChikisistemaDbContext db;

        public ByUnidadAlumnoValidator(IChikisistemaDbContext db)
        {
            this.db = db;
            RuleFor(el => el.IdUnidad).GreaterThan(0).NotEmpty();
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<ByUnidadAlumnoQuery> context, CancellationToken cancellation = default)
        {
            ValidationResult result = new ValidationResult();
            var request = context.InstanceToValidate;
            bool unidadExiste = await db.Unidad.AnyAsync(el => el.Id == request.IdUnidad);
            if (!unidadExiste)
            {
                throw new NotFoundException(nameof(Unidad), request.IdUnidad);
            }

            return result;
        }
    }
}