using System;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesCalendar
{
    public class GetAllActividadesCalendarResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime? FechaActivacion { get; set; }
        public string Contenido { get; set; }
        public int Valor { get; set; }
        public string TipoActividad { get; set; }

        public int IdUnidad { get; set; }
        public string Unidad { get; set; }

        public int IdCurso { get; set; }
        public string Curso { get; set; }
        public string Materia { get; set; }

        public string NombreMaestro { get; set; }
        public string UsuarioMaestro { get; set; }

        public int? Calificacion { get; set; }
        public bool Calificado { get; set; }
        public bool Respondido { get; set; }
        public bool Retrasado { get; set; }
        public bool Activado { get; set; }
        public bool Bloqueado { get; set; }

        public CalendarState Status => (Calificado, Respondido, Retrasado, Activado, Bloqueado) switch
        {
            (true, _, _, _, _) => CalendarState.Calificado,
            (_, true, _, _, _) => CalendarState.Entregado,
            (_, _, _, _, true) => CalendarState.Bloqueado,
            (_, _, true, _, _) => CalendarState.Retrasado,
            (_, _, _, true, _) => CalendarState.PendienteActivada,
            (_, _, _, false, _) => CalendarState.PendienteNoActivada,
        };
    }

    public enum CalendarState
    {
        Calificado,
        Entregado,
        Retrasado,
        Bloqueado,
        PendienteActivada,
        PendienteNoActivada
    }
}