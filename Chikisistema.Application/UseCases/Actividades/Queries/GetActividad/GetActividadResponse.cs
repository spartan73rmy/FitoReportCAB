using System;
using System.Collections.Generic;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetActividad
{
    public class GetActividadResponse
    {
        public int Id { get; set; }
        public int IdUnidad { get; set; }
        public string Titulo { get; set; }
        public string TipoActividad { get; set; }
        public int IdTipoActividad { get; set; }
        public string Contenido { get; set; }
        public int Valor { get; set; }
        public IEnumerable<MaterialApoyoDto> MaterialApoyo { get; set; }
        public DateTime? FechaActivacion { get; set; }
        public DateTime FechaLimite { get; set; }
        public bool BloquearEnvios { get; set; }

        public class MaterialApoyoDto
        {
            public string Hash { get; set; }
            public string Descripcion { get; set; }
            public string ContentType { get; set; }
        }
    }
}