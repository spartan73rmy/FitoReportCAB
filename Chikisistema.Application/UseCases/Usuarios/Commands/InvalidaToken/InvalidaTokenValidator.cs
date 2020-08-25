using FluentValidation;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.InvalidaToken
{
    public class InvalidaTokenValidator : AbstractValidator<InvalidaTokenCommand>
    {
        public InvalidaTokenValidator()
        {
            RuleFor(el => el.RefreshToken).NotEmpty();
        }
    }
}