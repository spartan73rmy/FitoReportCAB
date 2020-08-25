using Chikisistema.Application.Interfaces;
using Chikisistema.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Queries.GetActividad
{
    public class GetActividadHandler : IRequestHandler<GetActividadQuery, GetActividadResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IDateTime dateTime;
        private readonly IUserAccessor currentUser;

        public GetActividadHandler(IChikisistemaDbContext db, IDateTime dateTime, IUserAccessor currentUser)
        {
            this.db = db;
            this.dateTime = dateTime;
            this.currentUser = currentUser;
        }

        public async Task<GetActividadResponse> Handle(GetActividadQuery request, CancellationToken cancellationToken)
        {
            var result = await db
                    .ActividadCurso
                    .Select(el => new GetActividadResponse
                    {
                        Id = el.Id,
                        IdUnidad = el.IdUnidad,
                        Titulo = el.Titulo,
                        Contenido = el.Contenido,
                        TipoActividad = el.TipoActividad.Nombre,
                        Valor = el.Valor,
                        FechaActivacion = el.FechaActivacion,
                        FechaLimite = el.FechaLimite,
                        IdTipoActividad = el.IdTipoActividad,
                        BloquearEnvios = el.BloquearEnvios,
                        MaterialApoyo = el.MaterialApoyo.Select(el2 => new GetActividadResponse.MaterialApoyoDto
                        {
                            ContentType = el2.ArchivoUsuario.ContentType,
                            Descripcion = el2.ArchivoUsuario.Nombre,
                            Hash = el2.ArchivoUsuario.Hash
                        })
                    }).SingleOrDefaultAsync(el => el.Id == request.IdActividad);

            // Si la actividad aun sigue bloqueada se oculta la informacion
            if (currentUser.TipoUsuario == Domain.Enums.TiposUsuario.Alumno)
            {
                if (result.FechaActivacion != null && dateTime.Now < result.FechaActivacion)
                {
                    result.Contenido = null;
                    result.MaterialApoyo = null;
                }
            }

            return result;
        }
    }
}