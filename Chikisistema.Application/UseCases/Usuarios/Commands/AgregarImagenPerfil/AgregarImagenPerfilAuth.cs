using Chikisistema.Application.Security;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.AgregarImagenPerfil
{
    public class AgregarImagenPerfilAuth : IAuthenticatedRequest<AgregarImagenPerfilCommand, AgregarImagenPerfilResponse>
    {
        public Task Validate(AgregarImagenPerfilCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}