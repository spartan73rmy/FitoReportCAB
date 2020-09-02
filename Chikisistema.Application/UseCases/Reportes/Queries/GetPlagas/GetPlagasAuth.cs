using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Reportes.Queries.GetPlagas
{
    public class GetPlagasAuth : IAuthenticatedRequest<GetPlagasQuery, IEnumerable<GetPlagasResponse>>
    {
        private readonly IFitoReportDbContext db;
        private readonly IUserAccessor currentUser;

        public GetPlagasAuth(IFitoReportDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(GetPlagasQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
