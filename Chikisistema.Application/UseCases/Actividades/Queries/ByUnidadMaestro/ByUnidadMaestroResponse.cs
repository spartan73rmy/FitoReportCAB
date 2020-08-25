using System;

namespace Chikisistema.Application.UseCases.Actividades.Queries.ByUnidadMaestro
{
    public class ByUnidadMaestroResponse
    {
        public int IdActividad { get; set; }
        public string Titulo { get; set; }
        public string TipoActividad { get; set; }
        public bool BloquearEnvios { get; set; }
        public int Valor { get; set; }
        public DateTime FechaLimite { get; set; }
        public int NoRespuestas { get; set; }
        public int NoCalificacionesPendientes { get; set; }
    }
}