using System.Collections.Generic;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAlumnosByActividad
{
    public class GetAlumnosByActividadResponse
    {
        public int IdActividad { get; set; }
        public string TituloActividad { get; set; }
        public bool PuedeCalificar { get; set; }
        public IEnumerable<RespuestaAlumnos> Respuestas { get; set; }
        public int CalificacionMaxima { get; set; }

        public class RespuestaAlumnos
        {
            public int IdUsuario { get; set; }
            public string Nombre { get; internal set; }
            public string ApellidoPaterno { get; internal set; }
            public string ApellidoMaterno { get; internal set; }
            public string NombreCompleto => $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}";
            public string NombreUsuario { get; set; }
            public string Contenido { get; set; }
            public string Archivo { get; set; }
            public string ContentTypeArchivo { get; set; }
            public string NombreArchivo { get; set; }
            public int? Calificacion { get; set; }
            public bool Calificado => Calificacion != null;
        }
    }
}