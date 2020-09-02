using FitoReport.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FitoReport.Application.UseCases.Reportes.Queries.GetReporte
{
    public class GetReporteResponse
    {
        public int Id { get; set; }
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
        public virtual IList<EnfermedadDTO> Enfermedades { get; set; }
        public virtual IList<PlagaDTO> Plagas { get; set; }
        public virtual IList<Producto> Productos { get; set; }

        public class EnfermedadDTO
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        public class PlagaDTO
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        public class ProductoDTO
        {
            public int IdReport { get; set; }
            public int Cantidad { get; set; }
            public string NombreProducto { get; set; }
            public string IngredienteActivo { get; set; }
            public int Concentracion { get; set; }
            public string IntervaloSeguridad { get; set; }
        }
    }
}