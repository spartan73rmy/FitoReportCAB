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

namespace FitoReport.Application.UseCases.Reportes.Commands.AgregarEnfermedad
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
