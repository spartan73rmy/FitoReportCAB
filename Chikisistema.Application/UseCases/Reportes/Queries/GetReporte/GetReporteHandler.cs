using Chikisistema.Application.Interfaces;
using Chikisistema.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Reportes.Queries.GetReporte
{
    public class GetReporteHandler : IRequestHandler<GetReporteQuery, GetReporteResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IDateTime dateTime;
        private readonly IUserAccessor currentUser;

        public GetReporteHandler(IChikisistemaDbContext db, IDateTime dateTime, IUserAccessor currentUser)
        {
            this.db = db;
            this.dateTime = dateTime;
            this.currentUser = currentUser;
        }

        public async Task<GetReporteResponse> Handle(GetReporteQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

            //var result = await db
            //        .ActividadCurso
            //        .Select(el => new GetReporteResponse
            //        {
            //            Id = el.Id,
            //            IdUnidad = el.IdUnidad,
            //            Titulo = el.Titulo,
            //            Contenido = el.Contenido,
            //            TipoActividad = el.TipoActividad.Nombre,
            //            Valor = el.Valor,
            //            FechaActivacion = el.FechaActivacion,
            //            FechaLimite = el.FechaLimite,
            //            IdTipoActividad = el.IdTipoActividad,
            //            BloquearEnvios = el.BloquearEnvios,
            //            MaterialApoyo = el.MaterialApoyo.Select(el2 => new GetReporteResponse.MaterialApoyoDto
            //            {
            //                ContentType = el2.ArchivoUsuario.ContentType,
            //                Descripcion = el2.ArchivoUsuario.Nombre,
            //                Hash = el2.ArchivoUsuario.Hash
            //            })
            //        }).SingleOrDefaultAsync(el => el.Id == request.IdActividad);

            //// Si la actividad aun sigue bloqueada se oculta la informacion
            //if (currentUser.TipoUsuario == Domain.Enums.TiposUsuario.Alumno)
            //{
            //    if (result.FechaActivacion != null && dateTime.Now < result.FechaActivacion)
            //    {
            //        result.Contenido = null;
            //        result.MaterialApoyo = null;
            //    }
            //}

            //return result;
        }
    }
}