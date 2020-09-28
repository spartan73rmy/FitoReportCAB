using static FitoReport.Application.UseCases.Reportes.Queries.GetEtapaFenologicaList.GetEtapaFenologicaListResponse;
using FitoReport.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Reportes.Queries.GetEtapaFenologicaList
{
    public class GetEtapaFenologicaHandler : IRequestHandler<GetEtapaFenologicaListQuery, GetEtapaFenologicaListResponse>
    {
        private readonly IFitoReportDbContext db;

        public GetEtapaFenologicaHandler(IFitoReportDbContext db)
        {
            this.db = db;
        }

        public async Task<GetEtapaFenologicaListResponse> Handle(GetEtapaFenologicaListQuery request, CancellationToken cancellationToken)
        {
            var entity = await db.EtapaFenologica.Where(el => !el.IsDeleted).Select(el => new EtapaLookUpModel
            {
                Id = el.Id,
                Nombre = el.Nombre,
            }).OrderBy(el => el.Nombre).ToListAsync(cancellationToken);

            return new GetEtapaFenologicaListResponse { Etapas = entity };
        }
    }
}
