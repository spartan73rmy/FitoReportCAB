using System.Threading.Tasks;
using FitoReport.Application.UseCases.Reportes.Queries.GetEnfermedades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitoReport.WebUi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfermedadController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetEnfermedadesResponse>> GetEnfermedades()
        {
            return Ok(await Mediator.Send(new GetEnfermedadesQuery()));
        }
    }
}