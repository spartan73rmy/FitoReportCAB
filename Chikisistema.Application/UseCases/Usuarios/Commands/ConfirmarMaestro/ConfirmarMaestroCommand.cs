using MediatR;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.ConfirmarMaestro
{
    public class ConfirmarMaestroCommand : IRequest<ConfirmarMaestroResponse>
    {
        public int IdMaestro { get; set; }
    }
}