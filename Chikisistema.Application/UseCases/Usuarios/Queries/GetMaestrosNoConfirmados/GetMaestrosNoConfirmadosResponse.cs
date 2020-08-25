using System.Collections.Generic;

namespace Chikisistema.Application.UseCases.Usuarios.Queries.GetMaestrosNoConfirmados
{
    public class GetMaestrosNoConfirmadosResponse
    {
        public IEnumerable<MaestroDto> Maestros { get; set; }

        public class MaestroDto
        {
            public int Id { get; set; }
            public string NombreUsuario { get; set; }
        }
    }
}