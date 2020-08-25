﻿using Chikisistema.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Usuarios.Queries.GetUsuariosList
{
    public class GetUsuariosListQueryHandler : IRequestHandler<GetUsuariosListQuery, GetUsuariosListResponse>
    {
        private readonly IChikisistemaDbContext db;

        public GetUsuariosListQueryHandler(IChikisistemaDbContext db)
        {
            this.db = db;
        }

        public async Task<GetUsuariosListResponse> Handle(GetUsuariosListQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await db
                .Usuario
                .Select(el => new UsuarioLookupModel
                {
                    Id = el.Id,
                    Name = el.NombreUsuario
                })
                .ToListAsync(cancellationToken);

            return new GetUsuariosListResponse { Usuarios = usuarios };
        }
    }
}