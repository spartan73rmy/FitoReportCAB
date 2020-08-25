using FluentValidation;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.ConfirmarEmail
{
    public class ConfirmarEmailCommandValidator : AbstractValidator<ConfirmarEmailCommand>
    {
        public ConfirmarEmailCommandValidator()
        {
            RuleFor(el => el.Token).NotEmpty();
        }
    }
}