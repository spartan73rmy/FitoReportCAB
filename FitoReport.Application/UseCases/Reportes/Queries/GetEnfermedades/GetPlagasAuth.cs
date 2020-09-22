using FitoReport.Application.Interfaces;
using FitoReport.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Reportes.Queries.GetEnfermedades
{
    public class GetEnfermedadesAuth : IAuthenticatedRequest<GetEnfermedadesQuery, GetEnfermedadesResponse>
    {
        private readonly IFitoReportDbContext db;
        private readonly IUserAccessor currentUser;

        public GetEnfermedadesAuth(IFitoReportDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(GetEnfermedadesQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
