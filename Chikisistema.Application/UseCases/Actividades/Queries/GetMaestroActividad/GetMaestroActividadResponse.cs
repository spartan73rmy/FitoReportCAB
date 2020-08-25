using System;
using System.Collections.Generic;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetMaestroActividad
{
    public class GetMaestroActividadResponse
    {
        public int Id { get; set; }
        public int IdUnidad { get; set; }
        public string Titulo { get; set; }
        public string TipoActividad { get; set; }
        public int IdTipoActividad { get; set; }
        public string Contenido { get; set; }
        public int Valor { get; set; }
        public DateTime? FechaActivacion { get; set; }
        public DateTime FechaLimite { get; set; }
        public bool BloquearEnvios { get; set; }
        public IEnumerable<MaterialApoyoMaestroDto> MaterialApoyo { get; set; }
        public int NoRespuestas { get; set; }
        public int NoCalificacionesPendientes { get; set; }

        // Otro nombre de clase diferente al de la clase de getalumnoactividad para que el 
        // generador de api no cambie los nombres
        public class MaterialApoyoMaestroDto
        {
            public string Hash { get; set; }
            public string Descripcion { get; set; }
            public string ContentType { get; set; }
        }
    }
}