using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.UseCases.Report.Queries.GetReports
{
    public class GetReportsQuery : IRequest<IEnumerable<GetReportsResponse>>
    {
        
    }
}
