using FitoReport.Application.Interfaces;
using FitoReport.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Plagas.Commands.AgregarPlaga
{
    public class AgregarPlagaHandler : IRequestHandler<AgregarPlagaCommand, AgregarPlagaResponse>
    {
        private readonly IFitoReportDbContext db;

        public AgregarPlagaHandler(IFitoReportDbContext db)
        {
            this.db = db;
        }

        public async Task<AgregarPlagaResponse> Handle(AgregarPlagaCommand request, CancellationToken cancellationToken)
        {
            Plaga entity = new Plaga
            {
                Nombre = request.Nombre
            };

            db.Plaga.Add(entity);
            await db.SaveChangesAsync(cancellationToken);

            return new AgregarPlagaResponse
            {
                Id = entity.Id,
                Nombre = entity.Nombre
            };
        }
    }
}
