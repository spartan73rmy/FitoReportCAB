using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitoReport.Application.UseCases.Reportes.Commands.AgregarProducto
{
    public class AgregarProductoValidator : AbstractValidator<AgregarProductoCommand>
    {
        public AgregarProductoValidator()
        {
            
        }
    }
}
