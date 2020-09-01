using MediatR;

namespace Chikisistema.Application.UseCases.Reportes.Queries.GetReporte
{
    public class GetReporteQuery : IRequest<GetReporteResponse>
    {
        public int IdReporte { get; set; }
    }
}