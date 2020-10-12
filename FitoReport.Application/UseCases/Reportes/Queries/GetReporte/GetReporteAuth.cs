using FitoReport.Application.Interfaces;
using FitoReport.Application.Security;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Reportes.Queries.GetReporte
{
    public class GetReporteAuth : INotAuth<GetReporteQuery, GetReporteResponse>
    {
        public GetReporteAuth()
        {
        }

        public async Task Validate(GetReporteQuery request, ValidationResult validationResult)
        {
            await Task.CompletedTask;
        }
    }
}