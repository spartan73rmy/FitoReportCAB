using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitoReport.Application.UseCases.Usuarios.Commands.AproveUsuario
{
    public class AproveUsuarioCommand : IRequest<AproveUsuarioResponse>
    {
        public string NombreUsuario { get; set; }
    }
}
