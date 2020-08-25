using Chikisistema.Application.Interfaces;
using Chikisistema.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.AgregarActividad
{
    public class AgregarReporteHandler : IRequestHandler<AgregarReporteCommand, AgregarReporteResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IHtmlSanitizer sanitizer;

        public AgregarReporteHandler(IChikisistemaDbContext db, IHtmlSanitizer sanitizer)
        {
            this.db = db;
            this.sanitizer = sanitizer;
        }

        public async Task<AgregarReporteResponse> Handle(AgregarReporteCommand request, CancellationToken cancellationToken)
        {
            return new AgregarReporteResponse();
            //ActividadCurso entity = new ActividadCurso
            //{
            //    IdUnidad = request.IdUnidad,
            //    IdTipoActividad = request.IdTipoActividad,
            //    Titulo = request.Titulo,
            //    Contenido = sanitizer.Sanitize(request.Contenido),
            //    Valor = request.Valor,
            //    FechaLimite = request.FechaLimite,
            //    FechaActivacion = request.FechaActivacion
            //};

            //db.ActividadCurso.Add(entity);
            //await db.SaveChangesAsync(cancellationToken);

            //return new AgregarReporteResponse
            //{
            //    Id = entity.Id,
            //    IdUnidad = entity.IdUnidad,
            //    IdTipoActividad = entity.IdTipoActividad,
            //    Contenido = entity.Contenido,
            //    Valor = entity.Valor,
            //    FechaLimite = entity.FechaLimite,
            //    FechaActivacion = entity.FechaActivacion
            //};
        }
    }
}