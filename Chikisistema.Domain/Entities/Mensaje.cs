using System;

namespace Chikisistema.Domain.Entities
{
    public partial class Mensaje : BaseEntity
    {
        public int IdUsuarioEnvia { get; set; }
        public int IdUsuarioRecibe { get; set; }
        public string TextoMensaje { get; set; }
        public DateTime FechaMensaje { get; set; }

        public virtual Usuario IdUsuarioEnviaNavigation { get; set; }
        public virtual Usuario IdUsuarioRecibeNavigation { get; set; }
    }
}
