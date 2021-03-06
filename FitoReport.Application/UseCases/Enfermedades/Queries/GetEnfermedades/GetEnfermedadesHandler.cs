using FitoReport.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Enfermedades.Queries.GetEnfermedades
{
    public class GetEnfermedadesHandler : IRequestHandler<GetEnfermedadesQuery, GetEnfermedadesResponse>
    {
        private readonly IFitoReportDbContext db;

        public GetEnfermedadesHandler(IFitoReportDbContext db)
        {
            this.db = db;
        }

        public async Task<GetEnfermedadesResponse> Handle(GetEnfermedadesQuery request, CancellationToken cancellationToken)
        {
            var entity = await db.Enfermedad.Where(el => !el.IsDeleted).Select(el => new EnfermedadLookupModel
            {
                Id = el.Id,
                Nombre = el.Nombre,
            }).OrderBy(el => el.Nombre).ToListAsync(cancellationToken);

            return new GetEnfermedadesResponse { Enfermedades = entity };
        }
    }
}
