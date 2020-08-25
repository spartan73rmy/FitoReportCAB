namespace Chikisistema.Domain.Entities
{
    public class Plaga:BaseEntity
    {
        public int IdReport { get; set; }
        public string Nombre { get; set; }
        public virtual Report Report { get; set; }

    }
}