using System;
using System.Collections.Generic;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAlumnoActividad
{
    public class GetAlumnoActividadResponse
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
        public int? Calificacion { get; set; }
        public bool? Retrasado { get; set; }
        public bool Entregada { get; set; }
        public string ContenidoRespuesta { get; set; }

        public string Archivo { get; set; }
        public string NombreArchivo { get; set; }
        public string ContentTypeArchivo { get; set; }

        public class MaterialApoyoDto
        {
            public string Hash { get; set; }
            public string Descripcion { get; set; }
            public string ContentType { get; set; }
        }
    }
}