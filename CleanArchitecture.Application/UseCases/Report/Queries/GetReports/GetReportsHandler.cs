using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UseCases.Report.Queries.GetReports
{
    public class GetReportsHandler : IRequestHandler<GetReportsQuery, IEnumerable<GetReportsResponse>>
    {
        private readonly ICleanArchitectureDbContext db;

        public GetReportsHandler(ICleanArchitectureDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<GetReportsResponse>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
