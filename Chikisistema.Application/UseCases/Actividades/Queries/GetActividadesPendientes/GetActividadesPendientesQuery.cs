using MediatR;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetActividadesPendientes
{
    public class GetActividadesPendientesQuery : IRequest<GetActividadesPendientesResponse>
    {
        public int IdCurso { get; set; }
    }
}