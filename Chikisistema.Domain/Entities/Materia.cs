using System.Collections.Generic;

namespace Chikisistema.Domain.Entities
{
    public partial class Materia : DeleteableEntity
    {
        public Materia()
        {
            Curso = new HashSet<Curso>();
        }

        public string Nombre { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
    }
}