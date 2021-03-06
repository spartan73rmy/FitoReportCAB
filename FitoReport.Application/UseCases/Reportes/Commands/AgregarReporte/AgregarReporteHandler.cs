using FitoReport.Application.Interfaces;
using FitoReport.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public AgregarReporteHandler(IFitoReportDbContext db)
        {
            this.db = db;
        }

        public async Task<AgregarReporteResponse> Handle(AgregarReporteCommand request, CancellationToken cancellationToken)
        {
            for (int count = 0; count < request.Reportes.Count; count++)
            {
                ReporteDTO item = request.Reportes[count];
                Reporte entity = new Reporte
                {
                    Lugar = item.Lugar,
                    Productor = item.Productor,
                    Latitude = item.Latitude,
                    Longitud = item.Longitud,
                    Ubicacion = item.Ubicacion,
                    Predio = item.Predio,
                    Cultivo = item.Cultivo,
                    Observaciones = item.Observaciones,
                    Litros = item.Litros,
                };

                db.Reporte.Add(entity);
                await db.SaveChangesAsync(cancellationToken);

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
                    string nombre = NormalizeString(plaga.Nombre);

                    Plaga oldPlaga = await
                        db.Plaga.Where(el =>
                        el.Nombre.Replace(" ", "").ToLower().Equals(nombre))
                        .FirstOrDefaultAsync();

                    if (oldPlaga == null)
                    {
                        Plaga newPlaga = new Plaga
                        {
                            Nombre = plaga.Nombre
                        };
                        db.Plaga.Add(newPlaga);
                        await db.SaveChangesAsync(cancellationToken);

                        entity.ReportePlaga.Add(new ReportePlaga { Plaga = newPlaga });
                    }
                    else
                    {
                        oldPlaga.IsDeleted = false;
                        oldPlaga.DeletedDate = null;
                        db.Plaga.Update(oldPlaga);
                        entity.ReportePlaga.Add(new ReportePlaga { Plaga = oldPlaga });
                    }
                }

                foreach (EtapaFenogolicaDTO etapa in item.EtapaFenologica)
                {
                    //Search if exist a Etapa with equals or similar name
                    string nombre = NormalizeString(etapa.Nombre);

                    EtapaFenologica oldEtapaF = await
                        db.EtapaFenologica.Where(el =>
                        el.Nombre.Replace(" ", "").ToLower().Equals(nombre))
                        .FirstOrDefaultAsync();

                    if (oldEtapaF == null)
                    {
                        var newEtapa = new EtapaFenologica
                        {
                            Nombre = etapa.Nombre
                        };
                        db.EtapaFenologica.Add(newEtapa);
                        await db.SaveChangesAsync(cancellationToken);

                        entity.ReporteEtapaFenologica.Add(new ReporteEtapaFenologica { EtapaFenologica = newEtapa });
                    }
                    else
                    {
                        oldEtapaF.IsDeleted = false;
                        oldEtapaF.DeletedDate = null;
                        db.EtapaFenologica.Update(oldEtapaF);
                        entity.ReporteEtapaFenologica.Add(new ReporteEtapaFenologica { EtapaFenologica = oldEtapaF });
                    }
                }

                foreach (EnfermedadDTO enfermedad in item.Enfermedades)
                {
                    //Search if exist a Enfermedad with equals or similar name
                    string nombre = NormalizeString(enfermedad.Nombre);

                    Enfermedad oldEnfermedad = await
                        db.Enfermedad.Where(el =>
                        el.Nombre.Replace(" ", "").ToLower().Equals(nombre))
                        .FirstOrDefaultAsync();

                    if (oldEnfermedad == null)
                    {
                        Enfermedad newEnfermedad = new Enfermedad
                        {
                            Nombre = enfermedad.Nombre
                        };
                        db.Enfermedad.Add(newEnfermedad);
                        await db.SaveChangesAsync(cancellationToken);

                        entity.ReporteEnfermedad.Add(new ReporteEnfermedad { Enfermedad = newEnfermedad });
                    }
                    else
                    {
                        oldEnfermedad.IsDeleted = false;
                        oldEnfermedad.DeletedDate = null;
                        db.Enfermedad.Update(oldEnfermedad);
                        entity.ReporteEnfermedad.Add(new ReporteEnfermedad { Enfermedad = oldEnfermedad });
                    }
                }
                await db.SaveChangesAsync(cancellationToken);
                request.Reportes[count].Id = entity.Id;
            }

            return new AgregarReporteResponse
            {
                Id = request.Reportes.Select(el => el.Id).ToList()
            };
        }

        private string NormalizeString(string toNormalize)
        {
            return NormalizeString(new[] { " ", ".", "," }, toNormalize);
        }
        private string NormalizeString(string[] charsToDelete, string toNormalize)
        {
            foreach (string item in charsToDelete)
            {
                toNormalize = toNormalize.Replace(
                   item, newValue: string.Empty);
            }
            return toNormalize.ToLower();
        }
    }
}