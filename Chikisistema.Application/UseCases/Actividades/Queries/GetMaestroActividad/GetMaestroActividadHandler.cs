using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetMaestroActividad
{
    public class GetMaestroActividadHandler : IRequestHandler<GetMaestroActividadQuery, GetMaestroActividadResponse>
    {
        private readonly IChikisistemaDbContext db;

        public GetMaestroActividadHandler(IChikisistemaDbContext db)
        {
            this.db = db;
        }

        public async Task<GetMaestroActividadResponse> Handle(GetMaestroActividadQuery request, CancellationToken cancellationToken)
        {
            var result = await
                db.ActividadCurso
                .Select(el => new GetMaestroActividadResponse
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
                    FechaActivacion = el.FechaActivacion,
                    NoRespuestas = el.UsuarioActividades.Count(),
                    NoCalificacionesPendientes = el.UsuarioActividades.Count(el => el.Calificacion == null),
                    MaterialApoyo = el.MaterialApoyo.Select(el2 => new GetMaestroActividadResponse.MaterialApoyoMaestroDto
                    {
                        ContentType = el2.ArchivoUsuario.ContentType,
                        Hash = el2.ArchivoUsuario.Hash,
                        Descripcion = el2.ArchivoUsuario.Nombre
                    })
                }).SingleOrDefaultAsync(el => el.Id == request.IdActividad);

            return result;
        }
    }
}