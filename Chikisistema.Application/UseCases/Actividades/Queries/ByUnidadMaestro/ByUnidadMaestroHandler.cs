using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.ByUnidadMaestro
{
    public class ByUnidadMaestroHandler : IRequestHandler<ByUnidadMaestroQuery, IEnumerable<ByUnidadMaestroResponse>>
    {
        private readonly IChikisistemaDbContext db;

        public ByUnidadMaestroHandler(IChikisistemaDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ByUnidadMaestroResponse>> Handle(ByUnidadMaestroQuery request, CancellationToken cancellationToken)
        {
            var response = await db
                .ActividadCurso
                .Where(el => el.IdUnidad == request.IdUnidad)
                .Select(el => new ByUnidadMaestroResponse
                {
                    BloquearEnvios = el.BloquearEnvios,
                    FechaLimite = el.FechaLimite,
                    IdActividad = el.Id,
                    TipoActividad = el.TipoActividad.Nombre,
                    Titulo = el.Titulo,
                    Valor = el.Valor,
                    NoRespuestas = el.UsuarioActividades.Count(),
                    NoCalificacionesPendientes = el.UsuarioActividades.Count(el => el.Calificacion == null)
                })
                .OrderBy(el => el.IdActividad)
                .ToListAsync();

            return response;
        }
    }
}