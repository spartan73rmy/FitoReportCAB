using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.BloquearActividad
{
    public class BloquearActividadHandler : IRequestHandler<BloquearActividadCommand, BloquearActividadResponse>
    {
        private readonly IChikisistemaDbContext db;

        public BloquearActividadHandler(IChikisistemaDbContext db)
        {
            this.db = db;
        }

        public async Task<BloquearActividadResponse> Handle(BloquearActividadCommand request, CancellationToken cancellationToken)
        {
            var actividad = await db
                .ActividadCurso
                .SingleOrDefaultAsync(el => el.Id == request.IdActividad);

            actividad.BloquearEnvios = true;

            await db.SaveChangesAsync(cancellationToken);

            return new BloquearActividadResponse
            {
                Id = actividad.Id
            };
        }
    }
}