using System;
using System.Collections.Generic;
using System.Text;

namespace FitoReport.Application.UseCases.Reportes.Queries.GetPlagas
{
    public class GetPlagasResponse
    {
        public IList<PlagaLookupModel> Plagas { get; set; }
    }

    public class PlagaLookupModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
