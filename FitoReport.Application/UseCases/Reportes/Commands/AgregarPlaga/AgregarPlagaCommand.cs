using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitoReport.Application.UseCases.Reportes.Commands.AgregarPlaga
{
    public class AgregarPlagaCommand : IRequest<AgregarPlagaResponse>
    {
        public string Nombre { get; set; }
    }
}
