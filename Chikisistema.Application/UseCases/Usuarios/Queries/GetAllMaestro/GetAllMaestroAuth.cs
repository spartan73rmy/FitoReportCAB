using Chikisistema.Application.Security;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Usuarios.Queries.GetAllMaestro
{
    public class GetAllMaestroAuth : IAdminRequest<GetAllMaestroQuery, GetAllMaestroResponse>
    {
        public Task Validate(GetAllMaestroQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}