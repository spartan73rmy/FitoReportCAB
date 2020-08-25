using System.Collections.Generic;

namespace Chikisistema.Domain.Entities
{
    public partial class TipoActividad : BaseEntity
    {
        public TipoActividad()
        {
            Actividades = new HashSet<ActividadCurso>();
        }

        public string Nombre { get; set; }

        public virtual ICollection<ActividadCurso> Actividades { get; set; }
    }
}
