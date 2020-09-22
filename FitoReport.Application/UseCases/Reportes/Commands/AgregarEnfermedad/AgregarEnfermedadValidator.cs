using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitoReport.Application.UseCases.Reportes.Commands.AgregarEnfermedad
{
    public class AgregarEnfermedadValidator : AbstractValidator<AgregarEnfermedadCommand>
    {
        public AgregarEnfermedadValidator()
        {
            
        }
    }
}
