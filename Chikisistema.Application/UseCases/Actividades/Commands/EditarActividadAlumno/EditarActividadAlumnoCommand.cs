using MediatR;

namespace Chikisistema.Application.UseCases.Actividades.Commands.EditarActividadAlumno
{
    public class EditarActividadAlumnoCommand : IRequest<EditarActividadAlumnoResponse>
    {
        public int IdActividad { get; set; }
        public string Contenido { get; set; }
        public string Archivo { get; set; }
    }
}