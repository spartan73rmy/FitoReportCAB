using System;
using System.Collections.Generic;
using System.Text;

namespace FitoReport.Application.UseCases.Reportes.Queries.GetEnfermedades
{
    public class GetEnfermedadesResponse
    {
        public IList<EnfermedadLookupModel> Enfermedades { get; set; }
    }

    public class EnfermedadLookupModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
