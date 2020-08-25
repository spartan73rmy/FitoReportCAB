using FluentValidation;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.ConfirmarMaestro
{
    public class ConfirmarMaestroValidator : AbstractValidator<ConfirmarMaestroCommand>
    {
        public ConfirmarMaestroValidator()
        {
            RuleFor(el => el.IdMaestro).GreaterThan(0).NotEmpty();
        }
    }
}