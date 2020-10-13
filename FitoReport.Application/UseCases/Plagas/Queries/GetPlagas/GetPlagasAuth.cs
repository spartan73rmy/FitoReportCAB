using FitoReport.Application.Security;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Plagas.Queries.GetPlagas
{
    public class GetPlagasAuth : IAuthenticatedRequest<GetPlagasQuery, GetPlagasResponse>
    {
        public GetPlagasAuth()
        {
        }

        public Task Validate(GetPlagasQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
