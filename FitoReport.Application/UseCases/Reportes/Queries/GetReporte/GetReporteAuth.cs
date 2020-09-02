using FitoReport.Application.Exceptions;
using FitoReport.Application.Interfaces;
using FitoReport.Application.Security;
using FitoReport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Reportes.Queries.GetReporte
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