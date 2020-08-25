using MediatR;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.ModificarEmail
{
    public class ModificarEmailCommand : IRequest<ModificarEmailResponse>
    {
        public string NuevoEmail { get; set; }
        public string Password { get; set; }
    }
}