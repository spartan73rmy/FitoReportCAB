namespace Chikisistema.Domain.Entities
{
    public class PostForo : BaseEntity
    {
        public int IdAutor { get; set; }
        public string Contenido { get; set; }

        public virtual Usuario Autor { get; set; }
    }
}
