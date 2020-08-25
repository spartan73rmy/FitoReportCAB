using MediatR;
using System.Collections.Generic;

namespace Chikisistema.Application.UseCases.Actividades.Queries.ByUnidadMaestro
{
    public class ByUnidadMaestroQuery : IRequest<IEnumerable<ByUnidadMaestroResponse>>
    {
        public int IdUnidad { get; set; }
    }
}