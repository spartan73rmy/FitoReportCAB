using MediatR;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetActividad
{
    public class GetReporteQuery : IRequest<GetReporteResponse>
    {
        public int IdActividad { get; set; }
    }
}