using MediatR;

namespace Chikisistema.Application.UseCases.Actividades.Commands.SubirArchivoAlumno
{
    public class SubirActividadAlumnoCommand : IRequest<SubirActividadAlumnoResponse>
    {
        public int IdActividad { get; set; }
        public string Contenido { get; set; }
        public string Archivo { get; set; }
    }
}