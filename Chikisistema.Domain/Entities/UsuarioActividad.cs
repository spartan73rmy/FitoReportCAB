using System;

namespace Chikisistema.Domain.Entities
{
    public partial class UsuarioActividad : BaseEntity
    {
        public int IdUsuario { get; set; }
        public int IdActividad { get; set; }
        public string Contenido { get; set; }
        public int? IdArchivo { get; set; }
        public int? Calificacion { get; set; }
        public DateTime FechaEntrega { get; set; }

        public virtual ArchivoUsuario Archivo { get; set; }
        public virtual ActividadCurso ActividadCurso { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
