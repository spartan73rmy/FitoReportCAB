using System.Collections.Generic;

namespace Chikisistema.Domain.Entities
{
    public class ComentarioActividad : BaseEntity
    {
        public ComentarioActividad()
        {
            Hijos = new HashSet<ComentarioActividad>();
        }
        public string Contenido { get; set; }
        public int IdActividad { get; set; }
        public int? IdComentarioPadre { get; set; }
        public int IdUsuario { get; set; }


        public virtual Usuario Usuario { get; set; }
        public virtual ActividadCurso Actividad { get; set; }
        public virtual ComentarioActividad ComentarioPadre { get; set; }
        public virtual ICollection<ComentarioActividad> Hijos { get; set; }
    }
}
