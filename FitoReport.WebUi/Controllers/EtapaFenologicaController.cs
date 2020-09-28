using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitoReport.Application.UseCases.Reportes.Queries.GetEtapaFenologicaList;

namespace FitoReport.WebUi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtapaFenologicaController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetEtapaFenologicaListResponse>> GetAllEtapas()
        {
            return Ok(await Mediator.Send(new GetEtapaFenologicaListQuery()));
        }
    }
}