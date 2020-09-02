using FitoReport.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace FitoReport.Application.UseCases.Reportes.Commands.AgregarReporte
{
    public class AgregarReporteCommand : IRequest<AgregarReporteResponse>
    {
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
        //public virtual ICollection<ReporteEnfermedad> ReporteEnfermedad { get; set; }
        //public virtual ICollection<ReportePlaga> ReportePlaga { get; set; }
        //public virtual ICollection<Producto> Productos { get; set; }

    }
}