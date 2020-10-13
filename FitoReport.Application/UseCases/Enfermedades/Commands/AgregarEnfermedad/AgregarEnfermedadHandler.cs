using FitoReport.Application.Interfaces;
using FitoReport.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Enfermedades.Commands.AgregarEnfermedad
{
    public class AgregarEnfermedadHandler : IRequestHandler<AgregarEnfermedadCommand, AgregarEnfermedadResponse>
    {
        private readonly IFitoReportDbContext db;

        public AgregarEnfermedadHandler(IFitoReportDbContext db)
        {
            this.db = db;
        }

        public async Task<AgregarEnfermedadResponse> Handle(AgregarEnfermedadCommand request, CancellationToken cancellationToken)
        {
            Enfermedad entity = new Enfermedad
            {
                Nombre = request.Nombre,
            };

            db.Enfermedad.Add(entity);
            await db.SaveChangesAsync(cancellationToken);

            return new AgregarEnfermedadResponse
            {
                Id = entity.Id,
                Nombre = entity.Nombre
            };
        }
    }
}
