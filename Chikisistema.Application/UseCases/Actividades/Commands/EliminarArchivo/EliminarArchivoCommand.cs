using MediatR;

namespace Chikisistema.Application.UseCases.Actividades.Commands.EliminarArchivo
{
    public class EliminarArchivoCommand : IRequest<EliminarArchivoResponse>
    {
        public int IdActividad { get; set; }
        public string Archivo { get; set; }
    }
}