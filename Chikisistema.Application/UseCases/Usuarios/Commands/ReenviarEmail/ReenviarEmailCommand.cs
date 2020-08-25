using MediatR;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.ReenviarEmail
{
    public class ReenviarEmailCommand : IRequest<ReenviarEmailResponse>
    {
        public string Email { get; set; }
    }
}