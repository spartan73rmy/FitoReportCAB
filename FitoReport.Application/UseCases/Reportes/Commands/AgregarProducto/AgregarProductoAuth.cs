using FitoReport.Application.Interfaces;
using FitoReport.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Reportes.Commands.AgregarProducto
{
    public class AgregarProductoAuth : IAdminRequest<AgregarProductoCommand, AgregarProductoResponse>
    {
        private readonly IFitoReportDbContext db;
        private readonly IUserAccessor currentUser;

        public AgregarProductoAuth(IFitoReportDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(AgregarProductoCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
