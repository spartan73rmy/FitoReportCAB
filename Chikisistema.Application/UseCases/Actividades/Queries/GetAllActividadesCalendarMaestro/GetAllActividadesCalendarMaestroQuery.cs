using MediatR;
using System;
using System.Collections.Generic;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesCalendarMaestro
{
    public class GetAllActividadesCalendarMaestroQuery : IRequest<IEnumerable<GetAllActividadesCalendarMaestroResponse>>
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}