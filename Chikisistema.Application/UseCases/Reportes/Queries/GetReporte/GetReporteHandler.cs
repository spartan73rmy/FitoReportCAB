using Chikisistema.Application.Interfaces;
using Chikisistema.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Chikisistema.Application.UseCases.Reportes.Queries.GetReporte.GetReporteResponse;

namespace Chikisistema.Application.UseCases.Reportes.Queries.GetReporte
{
    public class GetReporteHandler : IRequestHandler<GetReporteQuery, GetReporteResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IDateTime dateTime;
        private readonly IUserAccessor currentUser;

        public GetReporteHandler(IChikisistemaDbContext db, IDateTime dateTime, IUserAccessor currentUser)
        {
            this.db = db;
            this.dateTime = dateTime;
            this.currentUser = currentUser;
        }

        public async Task<GetReporteResponse> Handle(GetReporteQuery query, CancellationToken cancellationToken)
        {
            var entity = await db
                .Reporte
                .Where(m => m.Id == query.IdReporte)
                .Select(request => new GetReporteResponse
                {
                    Id = request.Id,
                    Lugar = request.Lugar,
                    FechaAlta = request.FechaAlta,
                    Productor = request.Productor,
                    CoordX = request.CoordX,
                    CoordY = request.CoordY,
                    Ubicacion = request.Ubicacion,
                    Predio = request.Predio,
                    Cultivo = request.Cultivo,
                    EtapaFenologica = request.EtapaFenologica,
                    Observaciones = request.Observaciones,
                    Litros = request.Litros,
                    Enfermedades = request.ReporteEnfermedad.Where(el => el.IdReporte == query.IdReporte).Select(el => new EnfermedadDTO()
                    {
                        Id = el.Enfermedad.Id,
                        Nombre = el.Enfermedad.Nombre,
                    }).ToList(),
                    Plagas = request.ReportePlaga.Where(el => el.IdReporte == query.IdReporte).Select(el => new PlagaDTO
                    {
                        Id = el.Plaga.Id,
                        Nombre = el.Plaga.Nombre,
                    }).ToList(),
                    Productos = request.Productos.ToList(),

                }).FirstOrDefaultAsync();
            return entity;
        }
    }
}