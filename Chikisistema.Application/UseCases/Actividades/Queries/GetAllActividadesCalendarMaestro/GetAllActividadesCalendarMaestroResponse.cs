using System;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesCalendarMaestro
{
    public class GetAllActividadesCalendarMaestroResponse
    {
        public int IdActividad { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaLimite { get; set; }
        public int Valor { get; set; }
        public string TipoActividad { get; set; }

        public int IdUnidad { get; set; }
        public string Unidad { get; set; }

        public int IdCurso { get; set; }
        public string Curso { get; set; }
        public string Materia { get; set; }
        public bool Bloqueado { get; set; }

        public int RespuestasPendientes { get; set; }
        public int RespuestasAlumnos { get; set; }

        public CalendarStateMaestro Status => (Bloqueado, RespuestasPendientes) switch
        {
            (false, _) => CalendarStateMaestro.Activada,
            (true, 0) => CalendarStateMaestro.Finalizado,
            (_, _) => CalendarStateMaestro.CalificacionesPendientes
        };

        public enum CalendarStateMaestro
        {
            Finalizado,
            CalificacionesPendientes,
            Activada
        }
    }
}