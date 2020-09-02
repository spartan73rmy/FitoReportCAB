using System.Collections.Generic;

namespace FitoReport.Domain.Entities
{
    public class Plaga:BaseEntity
    {
        public int IdReport { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<ReportePlaga>ReportPlaga { get; set; }

    }
}