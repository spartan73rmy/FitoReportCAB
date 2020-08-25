using FluentValidation;

namespace Chikisistema.Application.UseCases.Archivos.Commands.AgregarArchivo
{
    public class AgregarArchivoValidator : AbstractValidator<AgregarArchivoCommand>
    {
        public AgregarArchivoValidator()
        {
            RuleFor(el => el.Archivo).NotEmpty();
            RuleFor(el => el.ContentType).NotEmpty();
            RuleFor(el => el.Nombre).NotEmpty();
        }
    }
}