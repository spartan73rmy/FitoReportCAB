using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Report.Queries.GetReports
{
    public class GetReportsAuth : IAdminRequest<GetReportsQuery, IEnumerable<GetReportsResponse>>
    {
        private readonly ICleanArchitectureDbContext db;
        private readonly IUserAccessor currentUser;

        public GetReportsAuth(ICleanArchitectureDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(GetReportsQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
