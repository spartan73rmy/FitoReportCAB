using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Usuarios.Queries.GetMaestrosNoConfirmados
{
    public class GetMaestrosNoConfirmadosHandler : IRequestHandler<GetMaestrosNoConfirmadosQuery, GetMaestrosNoConfirmadosResponse>
    {
        private readonly IChikisistemaDbContext db;

        public GetMaestrosNoConfirmadosHandler(IChikisistemaDbContext db)
        {
            this.db = db;
        }

        public async Task<GetMaestrosNoConfirmadosResponse> Handle(GetMaestrosNoConfirmadosQuery request, CancellationToken cancellationToken)
        {
            var maestrosNoConfirmados = await db
                .Usuario
                .Where(el => el.TipoUsuario == Domain.Enums.TiposUsuario.Maestro && el.Confirmado == false)
                .Select(el => new GetMaestrosNoConfirmadosResponse.MaestroDto
                {
                    Id = el.Id,
                    NombreUsuario = el.NombreUsuario
                })
                .ToListAsync();

            return new GetMaestrosNoConfirmadosResponse
            {
                Maestros = maestrosNoConfirmados
            };
        }
    }
}