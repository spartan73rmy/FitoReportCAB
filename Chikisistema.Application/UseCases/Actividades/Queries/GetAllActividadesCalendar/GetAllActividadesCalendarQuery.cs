using MediatR;
using System;
using System.Collections.Generic;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesCalendar
{
    public class GetAllActividadesCalendarQuery : IRequest<IEnumerable<GetAllActividadesCalendarResponse>>
    {
        public DateTime FirstDate;
        public DateTime SecondDate;
    }
}