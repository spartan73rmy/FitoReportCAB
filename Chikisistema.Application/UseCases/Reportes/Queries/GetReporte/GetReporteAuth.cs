using Chikisistema.Application.Exceptions;
using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Reportes.Queries.GetReporte
{
    public class GetReporteAuth : IAuthenticatedRequest<GetReporteQuery, GetReporteResponse>
    {
        private readonly IFitoReportDbContext db;
        private readonly IUserAccessor currentUser;

        public GetReporteAuth(IFitoReportDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(GetReporteQuery request, ValidationResult validationResult)
        {
            await Task.CompletedTask;            
        }
    }
}