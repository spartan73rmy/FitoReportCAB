using Chikisistema.Application.Interfaces;
using Chikisistema.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.AgregarActividad
{
    public class AgregarActividadHandler : IRequestHandler<AgregarActividadCommand, AgregarActividadResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IHtmlSanitizer sanitizer;

        public AgregarActividadHandler(IChikisistemaDbContext db, IHtmlSanitizer sanitizer)
        {
            this.db = db;
            this.sanitizer = sanitizer;
        }

        public async Task<AgregarActividadResponse> Handle(AgregarActividadCommand request, CancellationToken cancellationToken)
        {

            ActividadCurso entity = new ActividadCurso
            {
                IdUnidad = request.IdUnidad,
                IdTipoActividad = request.IdTipoActividad,
                Titulo = request.Titulo,
                Contenido = sanitizer.Sanitize(request.Contenido),
                Valor = request.Valor,
                FechaLimite = request.FechaLimite,
                FechaActivacion = request.FechaActivacion
            };

            db.ActividadCurso.Add(entity);
            await db.SaveChangesAsync(cancellationToken);

            return new AgregarActividadResponse
            {
                Id = entity.Id,
                IdUnidad = entity.IdUnidad,
                IdTipoActividad = entity.IdTipoActividad,
                Contenido = entity.Contenido,
                Valor = entity.Valor,
                FechaLimite = entity.FechaLimite,
                FechaActivacion = entity.FechaActivacion
            };
        }
    }
}