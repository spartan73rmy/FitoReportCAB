using System.Collections.Generic;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetActividadesPendientes
{
    public class GetActividadesPendientesResponse
    {
        public List<ActividadDto> Actividades { get; set; }

        public class ActividadDto
        {
            public int Id { get; set; }
            public int IdCurso { get; set; }
            public int IdUnidad { get; set; }
            public string Titulo { get; set; }
        }
    }
}