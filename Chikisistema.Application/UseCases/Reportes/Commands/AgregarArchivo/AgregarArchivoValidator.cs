using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Reportes.Commands.AgregarArchivo
{
    public class AgregarArchivoValidator : AbstractValidator<AgregarArchivoCommand>
    {
        private readonly IFitoReportDbContext db;

        public AgregarArchivoValidator(IFitoReportDbContext db)
        {
            RuleFor(el => el.Archivo).NotEmpty();
            RuleFor(el => el.IdActividad).NotEmpty().GreaterThan(0);
            this.db = db;
        }
    }
}