using MediatR;

namespace Chikisistema.Application.UseCases.Reportes.Queries.GetReporte
{
    public class GetReporteQuery : IRequest<GetReporteResponse>
    {
        public int IdActividad { get; set; }
    }
}