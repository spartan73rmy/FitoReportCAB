using FitoReport.Application.Exceptions;
using FitoReport.Application.Interfaces;
using FitoReport.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Reportes.Commands.AgregarArchivo
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