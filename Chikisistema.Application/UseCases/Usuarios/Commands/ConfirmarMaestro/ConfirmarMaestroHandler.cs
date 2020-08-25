using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.ConfirmarMaestro
{
    public class ConfirmarMaestroHandler : IRequestHandler<ConfirmarMaestroCommand, ConfirmarMaestroResponse>
    {
        private readonly IChikisistemaDbContext db;

        public ConfirmarMaestroHandler(IChikisistemaDbContext db)
        {
            this.db = db;
        }

        public async Task<ConfirmarMaestroResponse> Handle(ConfirmarMaestroCommand request, CancellationToken cancellationToken)
        {
            var maestro = await db.Usuario.SingleOrDefaultAsync(el => el.Id == request.IdMaestro);
           
            if (maestro == null)
            {
                throw new NotFoundException(nameof(Usuario), request.IdMaestro);
            }
            maestro.Confirmado = true;
            await db.SaveChangesAsync(cancellationToken);

            return new ConfirmarMaestroResponse { IdMaestro = maestro.Id };
        }
    }
}