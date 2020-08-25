using Chikisistema.Application.Security;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Usuarios.Queries.GetMaestrosNoConfirmados
{
    public class GetMaestrosNoConfirmadosAuth : IAdminRequest<GetMaestrosNoConfirmadosQuery, GetMaestrosNoConfirmadosResponse>
    {
        public Task Validate(GetMaestrosNoConfirmadosQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}