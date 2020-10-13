using System.Collections.Generic;

namespace FitoReport.Application.UseCases.EtapasFenologicas.Queries.GetEtapaFenologicaList
{
    public class GetEtapaFenologicaListResponse
    {
        public List<EtapaLookUpModel> Etapas { get; internal set; }
        public class EtapaLookUpModel
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }
    }
}
