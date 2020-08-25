using MediatR;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAlumnosByActividad
{
    public class GetAlumnosByActividadQuery : IRequest<GetAlumnosByActividadResponse>
    {
        public int IdActividad { get; set; }
    }
}