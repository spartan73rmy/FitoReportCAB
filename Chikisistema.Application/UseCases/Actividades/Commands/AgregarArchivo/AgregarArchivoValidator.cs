using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.AgregarArchivo
{
    public class AgregarArchivoValidator : AbstractValidator<AgregarArchivoCommand>
    {
        private readonly IChikisistemaDbContext db;

        public AgregarArchivoValidator(IChikisistemaDbContext db)
        {
            RuleFor(el => el.Archivo).NotEmpty();
            RuleFor(el => el.IdActividad).NotEmpty().GreaterThan(0);
            this.db = db;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<AgregarArchivoCommand> context, CancellationToken cancellation = default)
        {
            ValidationResult result = new ValidationResult();
            //var request = context.InstanceToValidate;
            //var actividad = await db
            //               .ActividadCurso
            //               .Where(el => el.Id == request.IdActividad)
            //               .Select(el => new
            //               {
            //                   Id = el.Id,
            //                   BloquearEnvios = el.BloquearEnvios
            //               })
            //               .SingleOrDefaultAsync();

            //if (actividad == null)
            //    throw new NotFoundException(nameof(ActividadCurso), request.IdActividad);

            //if (actividad.BloquearEnvios)
            //    result.Errors.Add(new ValidationFailure(nameof(request.Archivo), "No puedes agregar archivos, se han bloqueado los envios de la actividad"));

            return result;
        }
    }
}