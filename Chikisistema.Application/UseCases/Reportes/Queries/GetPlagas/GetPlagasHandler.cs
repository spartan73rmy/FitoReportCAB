using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Reportes.Queries.GetPlagas
{
    public class GetPlagasHandler : IRequestHandler<GetPlagasQuery, IEnumerable<GetPlagasResponse>>
    {
        private readonly IChikisistemaDbContext db;

        public GetPlagasHandler(IChikisistemaDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<GetPlagasResponse>> Handle(GetPlagasQuery request, CancellationToken cancellationToken)
        {
            var entity = await db.Plaga.Select(el => new GetPlagasResponse
            {
                Id = el.Id,
                Nombre = el.Nombre
            }).ToListAsync();

            return entity;
        }
    }
}
