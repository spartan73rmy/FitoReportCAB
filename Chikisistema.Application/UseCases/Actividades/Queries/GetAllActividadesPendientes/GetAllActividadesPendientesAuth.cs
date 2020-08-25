using Chikisistema.Application.Security;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesPendientes
{
    public class GetAllActividadesPendientesAuth : IAlumnoRequest<GetAllActividadesPendientesQuery, GetAllActividadesPendientesResponse>
    {
        public Task Validate(GetAllActividadesPendientesQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}