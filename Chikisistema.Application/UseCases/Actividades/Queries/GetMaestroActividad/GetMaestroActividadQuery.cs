using MediatR;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetMaestroActividad
{
    public class GetMaestroActividadQuery : IRequest<GetMaestroActividadResponse>
    {
        public int IdActividad { get; set; }
    }
}