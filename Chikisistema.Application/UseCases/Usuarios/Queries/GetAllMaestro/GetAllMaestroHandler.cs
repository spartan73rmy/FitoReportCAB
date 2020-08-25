using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Usuarios.Queries.GetAllMaestro
{
    public class GetAllMaestroHandler : IRequestHandler<GetAllMaestroQuery, GetAllMaestroResponse>
    {
        private readonly IChikisistemaDbContext db;

        public GetAllMaestroHandler(IChikisistemaDbContext db)
        {
            this.db = db;
        }

        public async Task<GetAllMaestroResponse> Handle(GetAllMaestroQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await db
                .Usuario
                .Where(el => el.TipoUsuario == Domain.Enums.TiposUsuario.Maestro)
                .Select(el => new MaestroLookupModel
                {
                    Id = el.Id,
                    Name = el.NombreUsuario,
                    Confirmado = el.Confirmado
                })
                .ToListAsync(cancellationToken);

            return new GetAllMaestroResponse { Usuarios = usuarios };
        }
    }
}