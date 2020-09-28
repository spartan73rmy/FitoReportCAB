using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitoReport.Application.UseCases.Usuarios.Commands.DeleteUsuario
{
    public class DeleteUsuarioCommand : IRequest<DeleteUsuarioResponse>
    {
        public string NombreUsuario { get; set; }
    }
}