using System.Collections.Generic;

namespace Chikisistema.Application.UseCases.Usuarios.Queries.GetUsuariosList
{
    public class GetUsuariosListResponse
    {
        public IList<UsuarioLookupModel> Usuarios { get; set; }
    }
}