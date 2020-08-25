namespace Chikisistema.Domain.Entities
{
    public class MaterialApoyoActividad : BaseEntity
    {
        public int IdArchivoUsuario { get; set; }
        public ArchivoUsuario ArchivoUsuario { get; set; }

        public int IdActividad { get; set; }
        public virtual ActividadCurso Actividad { get; set; }
    }
}
