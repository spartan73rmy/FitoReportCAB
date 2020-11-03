namespace FitoReport.Domain.Entities
{
    public class ArchivoReporte : BaseEntity
    {
        public ArchivoReporte()
        {
        }
        public int IdUsuario { get; set; }
        public int IdReporte { get; set; }
        public int? IdArchivo { get; set; }

        public virtual ArchivoUsuario Archivo { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
