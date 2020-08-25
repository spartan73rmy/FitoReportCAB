using System;
using System.Collections.Generic;

namespace Chikisistema.Domain.Entities
{
    public partial class Curso : DeleteableEntity
    {
        public Curso()
        {
            AlumnoCurso = new HashSet<AlumnoCurso>();
            Unidades = new HashSet<Unidad>();
        }

        public int IdMateria { get; set; }
        public int IdMaestro { get; set; }
        public string CodigoAcceso { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Descripcion { get; set; }

        public virtual Usuario IdMaestroNavigation { get; set; }
        public virtual Materia IdMateriaNavigation { get; set; }
        public virtual ICollection<AlumnoCurso> AlumnoCurso { get; set; }
        public virtual ICollection<Unidad> Unidades { get; set; }
    }
}