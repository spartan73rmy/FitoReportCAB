using MediatR;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.InvalidaToken
{
    public class InvalidaTokenCommand : IRequest<InvalidaTokenResponse>
    {
        public string RefreshToken { get; set; }
    }
}