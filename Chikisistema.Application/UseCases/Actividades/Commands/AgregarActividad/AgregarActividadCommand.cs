using MediatR;
using System;

namespace Chikisistema.Application.UseCases.Actividades.Commands.AgregarActividad
{
    public class AgregarActividadCommand : IRequest<AgregarActividadResponse>
    {
        public int IdUnidad { get; set; }
        public int IdTipoActividad { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public int Valor { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime? FechaActivacion { get; set; }
    }
}