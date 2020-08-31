using Chikisistema.Application.Interfaces;
using Chikisistema.Common;
using Chikisistema.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Reportes.Commands.AgregarReporte
{
    public class AgregarReporteHandler : IRequestHandler<AgregarReporteCommand, AgregarReporteResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IDateTime time;

        public AgregarReporteHandler(IChikisistemaDbContext db, IDateTime time)
        {
            this.db = db;
            this.time = time;
        }

        public async Task<AgregarReporteResponse> Handle(AgregarReporteCommand request, CancellationToken cancellationToken)
        {

            Reporte entity = new Reporte
            {
                Lugar = request.Lugar,
                FechaAlta = time.Now,
                Productor = request.Productor,
                CoordX = request.CoordX,
                CoordY = request.CoordY,
                Ubicacion = request.Ubicacion,
                Predio = request.Predio,
                Cultivo = request.Cultivo,
                EtapaFenologica = request.EtapaFenologica,
                Observaciones = request.Observaciones,
                Litros = request.Litros,
                Productos = new List<Producto>(),
                ReportePlaga = new List<ReportePlaga>(),
                ReporteEnfermedad = new List<ReporteEnfermedad>()
            };

            db.Reporte.Add(entity);
            await db.SaveChangesAsync(cancellationToken);

            return new AgregarReporteResponse
            {
                Id = entity.Id,
            };
        }
    }
}