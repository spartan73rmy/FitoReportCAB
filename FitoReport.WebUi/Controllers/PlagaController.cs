using FitoReport.Application.UseCases.Plagas.Queries.GetPlagas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitoReport.WebUi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlagaController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetPlagasResponse>> GetPlagas()
        {
            return Ok(await Mediator.Send(new GetPlagasQuery()));
        }
    }
}