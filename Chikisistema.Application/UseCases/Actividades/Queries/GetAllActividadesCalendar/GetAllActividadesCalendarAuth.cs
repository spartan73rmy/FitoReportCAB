using Chikisistema.Application.Security;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesCalendar
{
    public class GetAllActividadesCalendarAuth : IAlumnoRequest<GetAllActividadesCalendarQuery, IEnumerable<GetAllActividadesCalendarResponse>>
    {
        public Task Validate(GetAllActividadesCalendarQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}