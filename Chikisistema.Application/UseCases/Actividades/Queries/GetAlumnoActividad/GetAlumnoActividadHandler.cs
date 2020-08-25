using Chikisistema.Application.Interfaces;
using Chikisistema.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetAlumnoActividad
{
    public class GetAlumnoActividadHandler : IRequestHandler<GetAlumnoActividadQuery, GetAlumnoActividadResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IDateTime dateTime;
        private readonly IUserAccessor currentUser;

        public GetAlumnoActividadHandler(IChikisistemaDbContext db, IDateTime dateTime, IUserAccessor currentUser)
        {
            this.db = db;
            this.dateTime = dateTime;
            this.currentUser = currentUser;
        }

        public async Task<GetAlumnoActividadResponse> Handle(GetAlumnoActividadQuery request, CancellationToken cancellationToken)
        {
            int currentAlumno = currentUser.UserId;
            var result = await
                db.ActividadCurso
                .Select(el => new GetAlumnoActividadResponse
                {
                    Id = el.Id,
                    BloquearEnvios = el.BloquearEnvios,
                    FechaLimite = el.FechaLimite,
                    IdTipoActividad = el.IdTipoActividad,
                    IdUnidad = el.IdUnidad,
                    Titulo = el.Titulo,
                    TipoActividad = el.TipoActividad.Nombre,
                    Contenido = el.Contenido,
                    Valor = el.Valor,
                    Calificacion = el.UsuarioActividades.SingleOrDefault(el => el.IdUsuario == currentAlumno).Calificacion,
                    Entregada = el.UsuarioActividades.Any(el => el.IdUsuario == currentAlumno),
                    Retrasado = el.UsuarioActividades.SingleOrDefault(el => el.IdUsuario == currentAlumno).FechaEntrega > el.FechaLimite,
                    Archivo = el.UsuarioActividades.SingleOrDefault(el => el.IdUsuario == currentAlumno).Archivo.Hash,
                    ContentTypeArchivo = el.UsuarioActividades.SingleOrDefault(el => el.IdUsuario == currentAlumno).Archivo.ContentType,
                    NombreArchivo = el.UsuarioActividades.SingleOrDefault(el => el.IdUsuario == currentAlumno).Archivo.Nombre,
                    ContenidoRespuesta = el.UsuarioActividades.SingleOrDefault(el => el.IdUsuario == currentAlumno).Contenido,
                    FechaActivacion = el.FechaActivacion,
                    MaterialApoyo = el.MaterialApoyo.Select(el2 => new GetAlumnoActividadResponse.MaterialApoyoDto
                    {
                        ContentType = el2.ArchivoUsuario.ContentType,
                        Hash = el2.ArchivoUsuario.Hash,
                        Descripcion = el2.ArchivoUsuario.Nombre
                    })
                }).SingleOrDefaultAsync(el => el.Id == request.IdActividad);

            if (result.FechaActivacion != null && dateTime.Now < result.FechaActivacion)
            {
                result.Contenido = null;
                result.MaterialApoyo = null;
            }

            return result;
        }
    }
}