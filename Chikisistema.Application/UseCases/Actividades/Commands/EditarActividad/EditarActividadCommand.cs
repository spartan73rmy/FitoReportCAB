using MediatR;
using System;

namespace Chikisistema.Application.UseCases.Actividades.Commands.EditarActividad
{
    public class EditarActividadCommand : IRequest<EditarActividadResponse>
    {
        public int IdActividad { get; set; }
        public int IdTipoActividad { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public int Valor { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime? FechaActivacion { get; set; }
    }
}