using Chikisistema.Application.UseCases.Archivos.Commands.AgregarArchivo;
using Chikisistema.Application.UseCases.Archivos.Queries.DescargarArchivo;
using Chikisistema.Application.UseCases.Archivos.Queries.TokenDescarga;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chikisistema.WebUi.Controllers
{
    public class ArchivosController : BaseController
    {
        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<AgregarArchivoResponse>> AgregarArchivo(IFormFile command)
        {
            using (var file = command.OpenReadStream())
            {
                return Ok(await Mediator.Send(new AgregarArchivoCommand
                {
                    Archivo = file,
                    ContentType = command.ContentType,
                    Nombre = command.FileName
                }));
            }
        }

        [HttpPost]
        public async Task<ActionResult<TokenDescargaResponse>> GeneraTokenDescarga(TokenDescargaQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("{hash}")]
        [AllowAnonymous]
        public async Task<FileResult> DescargarArchivo(string hash, string token)
        {
            var file = await Mediator.Send(new DescargarArchivoQuery { Hash = hash, TokenDescarga = token });
            return File(file.Archivo, file.ContentType, file.Nombre);
        }
    }
}