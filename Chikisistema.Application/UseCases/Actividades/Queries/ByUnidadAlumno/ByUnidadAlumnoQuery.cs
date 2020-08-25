using MediatR;
using System.Collections.Generic;

namespace Chikisistema.Application.UseCases.Actividades.Queries.ByUnidadAlumno
{
    public class ByUnidadAlumnoQuery : IRequest<IEnumerable<ByUnidadAlumnoResponse>>
    {
        public int IdUnidad { get; set; }
    }
}