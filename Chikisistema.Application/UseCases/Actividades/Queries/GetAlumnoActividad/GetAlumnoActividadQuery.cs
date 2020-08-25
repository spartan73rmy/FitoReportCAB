using MediatR;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAlumnoActividad
{
    public class GetAlumnoActividadQuery : IRequest<GetAlumnoActividadResponse>
    {
        public int IdActividad { get; set; }
    }
}