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

namespace FitoReport.Application.UseCases.EtapasFenologicas.Commands.AddEtapaFenologica
{
    public class AddEtapaFenologicaHandler : IRequestHandler<AddEtapaFenologicaCommand, AddEtapaFenologicaResponse>
    {
        private readonly IFitoReportDbContext db;

        public AddEtapaFenologicaHandler(IFitoReportDbContext db)
        {
            this.db = db;
        }

        public async Task<AddEtapaFenologicaResponse> Handle(AddEtapaFenologicaCommand request, CancellationToken cancellationToken)
        {
            //Search if exist a Etapa with equals or similar name
            string nombre = request.Nombre.ToLower().Trim();
            EtapaFenologica oldEtapa = await
                db.EtapaFenologica.Where(el =>
                el.Nombre.ToLower().Trim().Equals(nombre))
                .FirstOrDefaultAsync();

            if (oldEtapa == null)
            {
                EtapaFenologica newEtapa = new EtapaFenologica
                {
                    Nombre = request.Nombre
                };
                db.EtapaFenologica.Add(newEtapa);
            }
            else
            {
                oldEtapa.IsDeleted = false;
                oldEtapa.DeletedDate = null;           
            }
            await db.SaveChangesAsync(cancellationToken);

            return new AddEtapaFenologicaResponse();
        }
    }
}
