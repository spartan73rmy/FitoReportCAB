namespace Chikisistema.Domain.Entities
{
    public class Producto:BaseEntity
    {
        public Producto()
        {

        }
        public int IdReport { get; set; }
        public int Cantidad { get; set; }
        public string NombreProducto { get; set; }
        public string IngredienteActivo { get; set; }
        public int Concentracion { get; set; }
        public string IntervaloSeguridad { get; set; }
        public virtual Reporte Report { get; set; }

    }
}