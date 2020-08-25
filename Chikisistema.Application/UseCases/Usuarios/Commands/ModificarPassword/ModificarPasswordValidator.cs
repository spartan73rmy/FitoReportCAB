using FluentValidation;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.ModificarPassword
{
    public class ModificarPasswordValidator : AbstractValidator<ModificarPasswordCommand>
    {
        public ModificarPasswordValidator()
        {
            RuleFor(el => el.PasswordActual).NotNull().NotEmpty();
            RuleFor(el => el.PasswordNuevo).NotNull().NotEmpty();
        }
    }
}