using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitoReport.Application.UseCases.Reportes.Commands.AgregarPlaga
{
    public class AgregarPlagaValidator : AbstractValidator<AgregarPlagaCommand>
    {
        public AgregarPlagaValidator()
        {
            
        }
    }
}
