using MediatR;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetActividad
{
    public class GetActividadQuery : IRequest<GetActividadResponse>
    {
        public int IdActividad { get; set; }
    }
}