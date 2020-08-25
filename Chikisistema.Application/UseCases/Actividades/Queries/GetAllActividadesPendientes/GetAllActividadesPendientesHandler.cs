using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesPendientes.GetAllActividadesPendientesResponse;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesPendientes
{
    public class GetAllActividadesPendientesHandler : IRequestHandler<GetAllActividadesPendientesQuery, GetAllActividadesPendientesResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public GetAllActividadesPendientesHandler(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task<GetAllActividadesPendientesResponse> Handle(GetAllActividadesPendientesQuery request, CancellationToken cancellationToken)
        {
            int idAlumno = currentUser.UserId;

            var actividades = await db
                .ActividadCurso
                .Where(el => el.BloquearEnvios == false
                    // Si la actividad pertenece a un curso donde el alumno este inscrito
                    && el.Unidad.Curso.AlumnoCurso.Any(alum => alum.IdAlumno == idAlumno)
                    // Si el alumno no ha contestado la actividad
                    && !el.UsuarioActividades.Any(res => res.IdUsuario == idAlumno)
                )
                .Select(el => new ActividadDto
                {
                    Id = el.Id,
                    IdUnidad = el.IdUnidad,
                    Titulo = el.Titulo
                })
                .ToListAsync();

            return new GetAllActividadesPendientesResponse { Actividades = actividades };
        }
    }
}