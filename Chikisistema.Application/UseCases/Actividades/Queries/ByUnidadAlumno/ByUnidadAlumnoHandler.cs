using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.ByUnidadAlumno
{
    public class ByUnidadAlumnoHandler : IRequestHandler<ByUnidadAlumnoQuery, IEnumerable<ByUnidadAlumnoResponse>>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public ByUnidadAlumnoHandler(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task<IEnumerable<ByUnidadAlumnoResponse>> Handle(ByUnidadAlumnoQuery request, CancellationToken cancellationToken)
        {
            var actividades = await db
                .ActividadCurso
                .Where(el => el.IdUnidad == request.IdUnidad)
                .Select(el => new ByUnidadAlumnoResponse
                {
                    Valor = el.Valor,
                    Entregada = el.UsuarioActividades.Any(actUsu => actUsu.IdUsuario == currentUser.UserId),
                    FechaLimite = el.FechaLimite,
                    BloquearEnvios = el.BloquearEnvios,
                    IdActividad = el.Id,
                    Titulo = el.Titulo,
                    Calificacion = el.UsuarioActividades.SingleOrDefault(actUs => actUs.IdUsuario == currentUser.UserId).Calificacion,
                    TipoActividad = el.TipoActividad.Nombre
                })
                .OrderBy(el => el.IdActividad)
                .ToListAsync();

            return actividades;
        }
    }
}