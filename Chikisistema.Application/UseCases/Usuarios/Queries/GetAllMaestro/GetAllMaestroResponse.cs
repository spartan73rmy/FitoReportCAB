using System.Collections.Generic;

namespace Chikisistema.Application.UseCases.Usuarios.Queries.GetAllMaestro
{
    public class GetAllMaestroResponse
    {
        public IList<MaestroLookupModel> Usuarios { get; set; }
    }
}