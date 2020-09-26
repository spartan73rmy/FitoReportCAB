﻿using FitoReport.Application.UseCases.Reportes.Commands.AgregarReporte;
using FitoReport.Application.UseCases.Reportes.Queries.GetPlagas;
using FitoReport.Application.UseCases.Reportes.Queries.GetReporte;
using FitoReport.Application.UseCases.Reportes.Queries.GetSearchReportList;
using FitoReport.WebUi.Controllers;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("{idReporte}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetReporteResponse>> Get([FromBody] GetReporteQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult<GetSearchReportListResponse>> GetSearchList()
        {
            return Ok(await Mediator.Send(new GetSearchReportListQuery()));
        }        
    }
}