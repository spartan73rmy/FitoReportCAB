using FitoReport.Application.UseCases.Reportes.Commands.AgregarReporte;
using FitoReport.Application.UseCases.Reportes.Queries.GetReporte;
using FitoReport.WebUi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitoReportCab.WebUi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<AgregarReporteResponse>> Agregar([FromBody] AgregarReporteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult<GetReporteResponse>> Get([FromBody] GetReporteQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}