using FitoReport.Application.UseCases.Enfermedades.Queries.GetEnfermedades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitoReport.WebUi.Controllers
{
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