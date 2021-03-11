using FitoReport.Application.UseCases.Archivos.Commands.AgregarArchivo;
using FitoReport.Application.UseCases.Archivos.Queries.DescargarArchivo;
using FitoReport.Application.UseCases.Archivos.Queries.TokenDescarga;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitoReport.WebUi.Controllers
{
    public class ArchivosController : BaseController
    {
        [HttpPost]
        [RequestSizeLimit(long.MaxValue)]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<AgregarArchivoResponse>> AgregarArchivo(IFormFile file, [FromFormAttribute] int idReporte)
        {
            using (var fileStream = file.OpenReadStream())
            {
                var result = await Mediator.Send(new AgregarArchivoCommand
                {
                    Archivo = fileStream,
                    ContentType = file.ContentType,
                    Nombre = file.FileName,
                    IdReporte = idReporte
                });
                return Ok(result);
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
        public async Task<FileResult> DescargarArchivo([FromHeader] string hashArchivo, [FromHeader]string tokenDescarga)
        {
            var hashe = hashArchivo + tokenDescarga;

            var file = await Mediator.Send(new DescargarArchivoQuery { Hash = hashArchivo, TokenDescarga = tokenDescarga });
            return File(file.Archivo, file.ContentType, file.Nombre);
        }
    }
}