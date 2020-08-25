using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.UseCases.Report.Queries.GetReports
{
    public class GetReportsValidator : AbstractValidator<GetReportsQuery>
    {
        public GetReportsValidator()
        {
            
        }
    }
}
