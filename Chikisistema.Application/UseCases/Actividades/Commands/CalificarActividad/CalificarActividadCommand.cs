using MediatR;

namespace Chikisistema.Application.UseCases.Actividades.Commands.CalificarActividad
{
    public class CalificarActividadCommand : IRequest<CalificarActividadResponse>
    {
        public int IdActividad { get; set; }
        public int IdAlumno { get; set; }
        public int Calificacion { get; set; }
    }
}