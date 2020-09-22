using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitoReport.Application.UseCases.Reportes.Commands.AgregarEnfermedad
{
    public class AgregarEnfermedadCommand : IRequest<AgregarEnfermedadResponse>
    {
        public string Nombre { get; set; }
    }
}
