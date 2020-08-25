using MediatR;

namespace Chikisistema.Application.UseCases.Actividades.Commands.AgregarArchivo
{
    public class AgregarArchivoCommand : IRequest<AgregarArchivoResponse>
    {
        public string Archivo { get; set; }
        public int IdActividad { get; set; }
    }
}