using System.Collections.Generic;

namespace FitoReport.Domain.Entities
{
    public class Enfermedad:BaseEntity
    {
        public int IdReport { get; set; }
        public string Nombre { get; set; }
        public ICollection<ReporteEnfermedad>ReporteEnfermedad { get; set; }

    }
}