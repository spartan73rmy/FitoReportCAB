using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesCalendarMaestro
{
    public class GetAllActividadesCalendarMaestroHandler : IRequestHandler<GetAllActividadesCalendarMaestroQuery, IEnumerable<GetAllActividadesCalendarMaestroResponse>>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public GetAllActividadesCalendarMaestroHandler(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task<IEnumerable<GetAllActividadesCalendarMaestroResponse>> Handle(GetAllActividadesCalendarMaestroQuery request, CancellationToken cancellationToken)
        {
            var actividades = await db
                .ActividadCurso
                .Where(el => el.Unidad.Curso.IdMaestro == currentUser.UserId && el.FechaLimite >= request.From && el.FechaLimite <= request.To)
                .Select(el => new GetAllActividadesCalendarMaestroResponse
                {
                    IdActividad = el.Id,
                    Bloqueado = el.BloquearEnvios,
                    Curso = el.Unidad.Curso.Descripcion,
                    FechaLimite = el.FechaLimite,
                    IdCurso = el.Unidad.IdCurso,
                    IdUnidad = el.IdUnidad,
                    Materia = el.Unidad.Curso.IdMateriaNavigation.Nombre,
                    RespuestasAlumnos = el.UsuarioActividades.Count(),
                    RespuestasPendientes = el.UsuarioActividades.Count(el => el.Calificacion == null),
                    TipoActividad = el.TipoActividad.Nombre,
                    Titulo = el.Titulo,
                    Unidad = el.Unidad.Descripcion,
                    Valor = el.Valor
                })
                .OrderBy(el => el.FechaLimite)
                .ToListAsync();

            return actividades;
        }
    }
}