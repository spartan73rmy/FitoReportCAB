using System.Collections.Generic;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesPendientes
{
    public class GetAllActividadesPendientesResponse
    {
        public List<ActividadDto> Actividades { get; set; }

        public class ActividadDto
        {
            public int Id { get; set; }
            public int IdUnidad { get; set; }
            public string Titulo { get; set; }
        }
    }
}