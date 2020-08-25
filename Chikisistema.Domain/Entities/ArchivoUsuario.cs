using System.Collections.Generic;

namespace Chikisistema.Domain.Entities
{
    public partial class ArchivoUsuario : BaseEntity
    {
        public ArchivoUsuario()
        {
            MaterialApoyo = new HashSet<MaterialApoyoActividad>();
        }

        public int IdUsuario { get; set; }
        public string Hash { get; set; }
        public string ContentType { get; set; }
        public string Nombre { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<MaterialApoyoActividad> MaterialApoyo { get; set; }
        public virtual ICollection<UsuarioActividad> UsuarioActividades { get; set; }
    }
}
