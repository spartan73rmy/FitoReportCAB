using Chikisistema.Application.Interfaces;
using Chikisistema.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.RecuperaPasswordGeneraToken
{
    public class RecuperaPasswordGeneraTokenHandler : IRequestHandler<RecuperaPasswordGeneraTokenCommand, RecuperaPasswordGeneraTokenResponse>
    {
        private readonly IFitoReportDbContext db;
        private readonly IRandomGenerator random;
        private readonly IMediator mediator;

        public RecuperaPasswordGeneraTokenHandler(IFitoReportDbContext db, IRandomGenerator random, IMediator mediator)
        {
            this.db = db;
            this.random = random;
            this.mediator = mediator;
        }

        public async Task<RecuperaPasswordGeneraTokenResponse> Handle(RecuperaPasswordGeneraTokenCommand request, CancellationToken cancellationToken)
        {
            var usuario = await db
                .Usuario
                .SingleOrDefaultAsync(el => el.Email == request.Email);

            if (usuario != null)
            {
                string token = random.Guid();
                usuario.TokenConfirmacion = token;

                await mediator.Publish(new RecuperaPasswordGeneraTokenNotificate
                {
                    Email = request.Email,
                    Token = token
                }, cancellationToken);

                await db.SaveChangesAsync(cancellationToken);
            }
            else
            {
                // Delay de 200ms a 1000
                await Task.Delay(random.Next(200, 1000));
            }
            return new RecuperaPasswordGeneraTokenResponse();
        }
    }
}