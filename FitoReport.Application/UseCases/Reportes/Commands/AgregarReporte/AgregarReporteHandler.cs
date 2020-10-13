using FitoReport.Application.Interfaces;
using FitoReport.Common;
using FitoReport.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static FitoReport.Application.UseCases.Reportes.Commands.AgregarReporte.AgregarReporteCommand;
using static FitoReport.Application.UseCases.Reportes.Commands.AgregarReporte.AgregarReporteCommand.ReporteDTO;

namespace FitoReport.Application.UseCases.Reportes.Commands.AgregarReporte
{
    public class AgregarReporteHandler : IRequestHandler<AgregarReporteCommand, AgregarReporteResponse>
    {
        private readonly IFitoReportDbContext db;
        private readonly IDateTime time;

        public AgregarReporteHandler(IFitoReportDbContext db, IDateTime time)
        {
            this.db = db;
            this.time = time;
        }

        public async Task<AgregarReporteResponse> Handle(AgregarReporteCommand request, CancellationToken cancellationToken)
        {

            foreach (ReporteDTO item in request.Reportes)
            {
                Reporte entity = new Reporte
                {
                    Lugar = item.Lugar,
                    Productor = item.Productor,
                    Latitude = item.Latitude,
                    Longitud = item.Longitud,
                    Ubicacion = item.Ubicacion,
                    Predio = item.Predio,
                    Cultivo = item.Cultivo,
                    EtapaFenologica = item.EtapaFenologica,
                    Observaciones = item.Observaciones,
                    Litros = item.Litros,
                };

                db.Reporte.Add(entity);
                foreach (ProductoDTO p in item.Productos)
                {
                    entity.Productos.Add(new Producto
                    {
                        IdReport = entity.Id,
                        Cantidad = p.Cantidad,
                        Unidad = p.Unidad,
                        Concentracion = p.Concentracion,
                        IngredienteActivo = p.IngredienteActivo,
                        IntervaloSeguridad = p.IntervaloSeguridad,
                        NombreProducto = p.Nombre,
                        Reporte = entity
                    });
                }

                foreach (PlagaDTO plaga in item.Plagas)
                {
                    //Search if exist a Plaga with equals or similar name
                    string nombre = plaga.Nombre.ToLower().Trim();
                    Plaga oldPlaga = await
                        db.Plaga.Where(el =>
                        el.Nombre.ToLower().Trim().Equals(nombre))
                        .FirstOrDefaultAsync();

                    if (oldPlaga == null)
                    {
                        Plaga newPlaga = new Plaga
                        {
                            Nombre = plaga.Nombre
                        };
                        db.Plaga.Add(newPlaga);
                        entity.ReportePlaga.Add(new ReportePlaga { Plaga = newPlaga });
                    }
                    else
                    { entity.ReportePlaga.Add(new ReportePlaga { Plaga = oldPlaga }); }
                }
                foreach (EnfermedadDTO enfermedad in item.Enfermedades)
                {
                    //Search if exist a Enfermedad with equals or similar name
                    string nombre = enfermedad.Nombre.ToLower().Trim();
                    Enfermedad oldEnfermedad = await
                        db.Enfermedad.Where(el =>
                        el.Nombre.ToLower().Trim().Equals(nombre))
                        .FirstOrDefaultAsync();

                    if (oldEnfermedad == null)
                    {
                        Enfermedad newEnfermedad = new Enfermedad
                        {
                            Nombre = enfermedad.Nombre
                        };
                        db.Enfermedad.Add(newEnfermedad);
                        entity.ReporteEnfermedad.Add(new ReporteEnfermedad { Enfermedad = newEnfermedad });
                    }
                    else
                    { entity.ReporteEnfermedad.Add(new ReporteEnfermedad { Enfermedad = oldEnfermedad }); }
                }
            }

            await db.SaveChangesAsync(cancellationToken);

            return new AgregarReporteResponse
            {
                Id = 0,
            };
        }
    }
}