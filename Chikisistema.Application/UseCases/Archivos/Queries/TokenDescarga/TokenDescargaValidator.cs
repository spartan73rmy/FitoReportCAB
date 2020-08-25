using FluentValidation;

namespace Chikisistema.Application.UseCases.Archivos.Queries.TokenDescarga
{
    public class TokenDescargaValidator : AbstractValidator<TokenDescargaQuery>
    {
        public TokenDescargaValidator()
        {
            RuleFor(el => el.HashArchivo).NotEmpty();
        }
    }
}