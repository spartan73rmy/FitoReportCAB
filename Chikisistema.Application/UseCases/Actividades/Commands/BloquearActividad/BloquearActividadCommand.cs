using MediatR;

namespace Chikisistema.Application.UseCases.Actividades.Commands.BloquearActividad
{
    public class BloquearActividadCommand : IRequest<BloquearActividadResponse>
    {
        public int IdActividad { get; set; }
    }
}