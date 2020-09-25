using System;
using System.Collections.Generic;
using System.Text;

namespace FitoReport.Application.UseCases.Reportes.Commands.AgregarProducto
{
    public class AgregarProductoResponse
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string NombreProducto { get; set; }
        public string IngredienteActivo { get; set; }
        public string Concentracion { get; set; }
        public string IntervaloSeguridad { get; set; }
    }
}
