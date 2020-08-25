using System.IO;

namespace Chikisistema.Application.UseCases.Archivos.Queries.DescargarArchivo
{
    public class DescargarArchivoResponse
    {
        public Stream Archivo { get; set; }
        public string ContentType { get; set; }
        public string Nombre { get; set; }
    }
}