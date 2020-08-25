using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.CalificarActividad
{
    public class CalificarActividadHandler : IRequestHandler<CalificarActividadCommand, CalificarActividadResponse>
    {
        private readonly IChikisistemaDbContext db;

        public CalificarActividadHandler(IChikisistemaDbContext db)
        {
            this.db = db;
        }

        public async Task<CalificarActividadResponse> Handle(CalificarActividadCommand request, CancellationToken cancellationToken)
        {
            var usuarioActividad = await db
                .UsuarioActividad
                .Include(el => el.ActividadCurso)
                .SingleOrDefaultAsync(el => el.IdActividad == request.IdActividad && el.IdUsuario == request.IdAlumno);

            usuarioActividad.Calificacion = request.Calificacion;

            await db.SaveChangesAsync(cancellationToken);

            return new CalificarActividadResponse
            {
                IdActividad = usuarioActividad.IdActividad,
                IdUsuario = usuarioActividad.IdUsuario,
                Calificacion = usuarioActividad.Calificacion.GetValueOrDefault(),
                Contenido = usuarioActividad.Contenido,
                Retrasado = usuarioActividad.FechaEntrega > usuarioActividad.ActividadCurso.FechaLimite
            };
        }
    }
}