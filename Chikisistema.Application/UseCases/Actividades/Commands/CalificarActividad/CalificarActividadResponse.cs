namespace Chikisistema.Application.UseCases.Actividades.Commands.CalificarActividad
{
    public class CalificarActividadResponse
    {
        public int IdUsuario { get; set; }
        public int IdActividad { get; set; }
        public string Contenido { get; set; }
        public int Calificacion { get; set; }
        public bool Retrasado { get; set; }
    }
}