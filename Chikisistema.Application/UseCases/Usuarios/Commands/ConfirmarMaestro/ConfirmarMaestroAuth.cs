using Chikisistema.Application.Security;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.ConfirmarMaestro
{
    public class ConfirmarMaestroAuth : IAdminRequest<ConfirmarMaestroCommand, ConfirmarMaestroResponse>
    {
        public Task Validate(ConfirmarMaestroCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}