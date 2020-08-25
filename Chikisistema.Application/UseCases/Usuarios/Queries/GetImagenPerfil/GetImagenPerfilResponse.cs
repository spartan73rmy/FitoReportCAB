using System.IO;

namespace Chikisistema.Application.UseCases.Usuarios.Queries.GetImagenPerfil
{
    public class GetImagenPerfilResponse
    {
        public Stream Imagen { get; set; }
        public string ContentType { get; set; }
    }
}