using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Chikisistema.Application.UseCases.Actividades.Queries.GetActividadesPendientes.GetActividadesPendientesResponse;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetActividadesPendientes
{
    public class GetActividadesPendientesHandler : IRequestHandler<GetActividadesPendientesQuery, GetActividadesPendientesResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public GetActividadesPendientesHandler(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task<GetActividadesPendientesResponse> Handle(GetActividadesPendientesQuery request, CancellationToken cancellationToken)
        {
            int idAlumno = currentUser.UserId;

            var actividades = await db
                .ActividadCurso
                // Si no se ha bloqueado la actividad y no ha subido la tarea el usuario
                .Where(
                  activ =>
                    activ.BloquearEnvios == false
                    && !activ.UsuarioActividades.Any(resp => resp.IdUsuario == currentUser.UserId)
                    && activ.Unidad.IdCurso == request.IdCurso
                 )
                .Select(el => new ActividadDto
                {
                    Id = el.Id,
                    IdUnidad = el.IdUnidad,
                    Titulo = el.Titulo,
                    IdCurso = el.Unidad.IdCurso
                })
                .ToListAsync();

            return new GetActividadesPendientesResponse { Actividades = actividades };
        }
    }
}