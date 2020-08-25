using FluentValidation;

namespace Chikisistema.Application.UseCases.Usuarios.Queries.GetImagenPerfil
{
    public class GetImagenPerfilValidator : AbstractValidator<GetImagenPerfilQuery>
    {
        public GetImagenPerfilValidator()
        {
            RuleFor(el => el.NombreUsuario).NotEmpty();
            RuleFor(el => el.Size).IsInEnum();
        }
    }
}