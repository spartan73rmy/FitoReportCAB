using System;
using System.Collections.Generic;

namespace Chikisistema.Domain.Entities
{
    public partial class ActividadCurso : DeleteableEntity
    {
        public ActividadCurso()
        {
            UsuarioActividades = new HashSet<UsuarioActividad>();
            MaterialApoyo = new HashSet<MaterialApoyoActividad>();
        }

        public int IdUnidad { get; set; }
        public int IdTipoActividad { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public int Valor { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime? FechaActivacion { get; set; }
        public bool BloquearEnvios { get; set; }

        public virtual Unidad Unidad { get; set; }
        public virtual TipoActividad TipoActividad { get; set; }
        public virtual ICollection<ComentarioActividad> Comentarios { get; set; }
        public virtual ICollection<UsuarioActividad> UsuarioActividades { get; set; }
        public virtual ICollection<MaterialApoyoActividad> MaterialApoyo { get; set; }
    }
}
