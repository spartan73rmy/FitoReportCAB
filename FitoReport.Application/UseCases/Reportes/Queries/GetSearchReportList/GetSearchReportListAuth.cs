using FitoReport.Application.Interfaces;
using FitoReport.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Reportes.Queries.GetSearchReportList
{
    public class GetSearchReportListAuth : IAuthenticatedRequest<GetSearchReportListQuery, GetSearchReportListResponse>
    {
        private readonly IFitoReportDbContext db;
        private readonly IUserAccessor currentUser;

        public GetSearchReportListAuth(IFitoReportDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(GetSearchReportListQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
