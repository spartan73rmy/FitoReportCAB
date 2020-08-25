using Chikisistema.Application.Interfaces;
using Chikisistema.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesCalendar
{
    public class GetAllActividadesCalendarHandler : IRequestHandler<GetAllActividadesCalendarQuery, IEnumerable<GetAllActividadesCalendarResponse>>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;
        private readonly IDateTime time;

        public GetAllActividadesCalendarHandler(IChikisistemaDbContext db, IUserAccessor currentUser, IDateTime time)
        {
            this.db = db;
            this.currentUser = currentUser;
            this.time = time;
        }

        public async Task<IEnumerable<GetAllActividadesCalendarResponse>> Handle(GetAllActividadesCalendarQuery request, CancellationToken cancellationToken)
        {
            int idAlumno = currentUser.UserId;

            var actividadesCorrespondientes = db
                     .ActividadCurso
                     .Where(el => el.Unidad.Curso.AlumnoCurso.Any(alum => alum.IdAlumno == idAlumno))
                     .Where(el => el.FechaLimite >= request.FirstDate && el.FechaLimite <= request.SecondDate);

            var actividadesRespondidas = db
                .UsuarioActividad
                .Where(el => el.IdUsuario == idAlumno);

            var actividades = await
                (from aCurso in actividadesCorrespondientes
                 join uActiv in actividadesRespondidas
                 on aCurso.Id equals uActiv.IdActividad into result
                 from objResult in result.DefaultIfEmpty()
                 select new GetAllActividadesCalendarResponse
                 {
                     Id = aCurso.Id,
                     IdUnidad = aCurso.IdUnidad,
                     Titulo = aCurso.Titulo,
                     FechaLimite = aCurso.FechaLimite,
                     FechaActivacion = aCurso.FechaActivacion,
                     Contenido = aCurso.Contenido,
                     Valor = aCurso.Valor,
                     TipoActividad = aCurso.TipoActividad.Nombre,

                     NombreMaestro = aCurso.Unidad.Curso.IdMaestroNavigation.Nombre + " " + aCurso.Unidad.Curso.IdMaestroNavigation.ApellidoPaterno + " " + aCurso.Unidad.Curso.IdMaestroNavigation.ApellidoMaterno,
                     UsuarioMaestro = aCurso.Unidad.Curso.IdMaestroNavigation.NombreUsuario,

                     Retrasado = aCurso.FechaLimite < time.Now && objResult == null,
                     Activado = aCurso.FechaActivacion == null || aCurso.FechaActivacion < time.Now,
                     Bloqueado = aCurso.BloquearEnvios,

                     Calificacion = objResult.Calificacion,
                     Calificado = objResult.Calificacion != null,
                     Respondido = objResult != null,

                     Curso = aCurso.Unidad.Curso.Descripcion,
                     Materia = aCurso.Unidad.Curso.IdMateriaNavigation.Nombre,
                     Unidad = aCurso.Unidad.Descripcion,

                     IdCurso = aCurso.Unidad.IdCurso

                 })
                 .OrderBy(el => el.FechaLimite)
                 .ToListAsync();

            return actividades;
        }
    }
}