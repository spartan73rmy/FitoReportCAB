using System.Collections.Generic;

namespace Chikisistema.Domain.Entities
{
    public class Unidad : DeleteableEntity
    {
        public Unidad()
        {
            Actividades = new HashSet<ActividadCurso>();
        }

        public int IdCurso { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<ActividadCurso> Actividades { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
