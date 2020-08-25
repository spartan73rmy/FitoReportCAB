using System;

namespace Chikisistema.Application.UseCases.Actividades.Queries.ByUnidadAlumno
{
    public class ByUnidadAlumnoResponse
    {
        public int IdActividad { get; set; }
        public string Titulo { get; set; }
        public string TipoActividad { get; set; }
        public bool Entregada { get; set; }
        public bool BloquearEnvios { get; set; }
        public int? Calificacion { get; set; }
        public int Valor { get; set; }
        public DateTime FechaLimite { get; set; }
    }
}