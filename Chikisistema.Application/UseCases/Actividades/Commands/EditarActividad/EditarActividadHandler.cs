using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.EditarActividad
{
    public class EditarActividadHandler : IRequestHandler<EditarActividadCommand, EditarActividadResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IHtmlSanitizer sanitizer;

        public EditarActividadHandler(IChikisistemaDbContext db, IHtmlSanitizer sanitizer)
        {
            this.db = db;
            this.sanitizer = sanitizer;
        }

        public async Task<EditarActividadResponse> Handle(EditarActividadCommand request, CancellationToken cancellationToken)
        {
            var actividad = await db
                .ActividadCurso
                .Where(el => el.Id == request.IdActividad)
                .SingleOrDefaultAsync();

            if (actividad == null)
            {
                throw new NotFoundException(nameof(request.IdActividad), request.IdActividad);
            }

            if (actividad.BloquearEnvios)
            {
                throw new BadRequestException("La actividad ya ha sido bloqueada");
            }

            actividad.IdTipoActividad = request.IdTipoActividad;
            actividad.Titulo = request.Titulo;
            actividad.Contenido = sanitizer.Sanitize(request.Contenido);
            actividad.Valor = request.Valor;
            actividad.FechaLimite = request.FechaLimite;
            actividad.FechaActivacion = request.FechaActivacion;

            await db.SaveChangesAsync(cancellationToken);

            return new EditarActividadResponse
            {
                Id = actividad.Id,
                IdUnidad = actividad.IdUnidad,
                IdTipoActividad = actividad.IdTipoActividad,
                Contenido = actividad.Contenido,
                Valor = actividad.Valor,
                FechaLimite = actividad.FechaLimite,
                FechaActivacion = actividad.FechaActivacion
            };
        }
    }
}