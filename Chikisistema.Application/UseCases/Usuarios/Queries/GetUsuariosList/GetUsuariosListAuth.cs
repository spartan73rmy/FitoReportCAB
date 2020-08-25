using Chikisistema.Application.Security;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Usuarios.Queries.GetUsuariosList
{
    public class GetUsuariosListAuth : IAdminRequest<GetUsuariosListQuery, GetUsuariosListResponse>
    {
        public Task Validate(GetUsuariosListQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}