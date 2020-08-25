using Chikisistema.Application.Security;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesCalendarMaestro
{
    public class GetAllActividadesCalendarMaestroAuth : IMaestroRequest<GetAllActividadesCalendarMaestroQuery, IEnumerable<GetAllActividadesCalendarMaestroResponse>>
    {
        public Task Validate(GetAllActividadesCalendarMaestroQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}