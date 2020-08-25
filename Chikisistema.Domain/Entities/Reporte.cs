using System;
using System.Collections.Generic;

namespace Chikisistema.Domain.Entities
{
    public class Reporte : BaseEntity
    {
        public Reporte()
        {
            Plagas = new HashSet<Plaga>();            
            Productos = new HashSet<Producto>();
            Enfermedades = new HashSet<Enfermedad>();
        }

        public string Lugar { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Productor { get; set; }
        public double CoordX { get; set; }
        public double CoordY { get; set; }
        public string Ubicacion { get; set; }
        public string Predio { get; set; }
        public string Cultivo { get; set; }
        public string EtapaFenologica { get; set; }
        public string Observaciones { get; set; }
        public int Litros { get; set; }
        public virtual ICollection<Enfermedad> Enfermedades { get; set; }
        public virtual ICollection<Plaga> Plagas { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
