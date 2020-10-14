using FitoReport.Application.Exceptions;
using FitoReport.Application.Interfaces;
using FitoReport.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Plagas.Commands.DeletePlaga
{
    public class DeletePlagaHandler : IRequestHandler<DeletePlagaCommand, DeletePlagaResponse>
    {
        private readonly IFitoReportDbContext db;

        public DeletePlagaHandler(IFitoReportDbContext db)
        {
            this.db = db;
        }

        public async Task<DeletePlagaResponse> Handle(DeletePlagaCommand request, CancellationToken cancellationToken)
        {
            Plaga entity = await db.Plaga.FindAsync(request.IdPlaga);

            db.Plaga.Remove(entity);
            await db.SaveChangesAsync(cancellationToken);

            return new DeletePlagaResponse();
        }
    }
}
