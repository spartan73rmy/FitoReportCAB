using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Reportes.Commands.EditarReporte
{
    public class EditarReporteHandler : IRequestHandler<EditarReporteCommand, EditarReporteResponse>
    {
        private readonly IFitoReportDbContext db;
        private readonly IHtmlSanitizer sanitizer;

        public EditarReporteHandler(IFitoReportDbContext db, IHtmlSanitizer sanitizer)
        {
            this.db = db;
            this.sanitizer = sanitizer;
        }

        public Task<EditarReporteResponse> Handle(EditarReporteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //var actividad = await db
            //    .ActividadCurso
            //    .Where(el => el.Id == request.IdActividad)
            //    .SingleOrDefaultAsync();

            //if (actividad == null)
            //{
            //    throw new NotFoundException(nameof(request.IdActividad), request.IdActividad);
            //}

            //if (actividad.BloquearEnvios)
            //{
            //    throw new BadRequestException("La actividad ya ha sido bloqueada");
            //}

            //actividad.IdTipoActividad = request.IdTipoActividad;
            //actividad.Titulo = request.Titulo;
            //actividad.Contenido = sanitizer.Sanitize(request.Contenido);
            //actividad.Valor = request.Valor;
            //actividad.FechaLimite = request.FechaLimite;
            //actividad.FechaActivacion = request.FechaActivacion;

            //await db.SaveChangesAsync(cancellationToken);

            //return new EditarReporteResponse
            //{
            //    Id = actividad.Id,
            //};
        }
    }
}