using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Actividades.Commands.EliminarArchivo
{
    public class EliminarArchivoHandler : IRequestHandler<EliminarArchivoCommand, EliminarArchivoResponse>
    {
        private readonly IChikisistemaDbContext db;

        public EliminarArchivoHandler(IChikisistemaDbContext db)
        {
            this.db = db;
        }

        public async Task<EliminarArchivoResponse> Handle(EliminarArchivoCommand request, CancellationToken cancellationToken)
        {
            var archivo = await db
                .ArchivoUsuario
                .Where(el => el.Hash == request.Archivo)
                .SelectMany(el => el.MaterialApoyo)
                .SingleOrDefaultAsync(el => el.IdActividad == request.IdActividad);

            db.MaterialApoyoActividad.Remove(archivo);
            await db.SaveChangesAsync(cancellationToken);

            return new EliminarArchivoResponse
            {

            };
        }
    }
}