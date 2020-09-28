using FitoReport.Application.Interfaces;
using FitoReport.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Reportes.Queries.GetEtapaFenologicaList
{
    public class GetEtapaFenologicaListAuth : IAdminRequest<GetEtapaFenologicaListQuery, GetEtapaFenologicaListResponse>
    {
        private readonly IFitoReportDbContext db;
        private readonly IUserAccessor currentUser;

        public GetEtapaFenologicaListAuth(IFitoReportDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(GetEtapaFenologicaListQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
