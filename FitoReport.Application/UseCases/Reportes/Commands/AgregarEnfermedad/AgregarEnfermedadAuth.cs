using FitoReport.Application.Interfaces;
using FitoReport.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Reportes.Commands.AgregarEnfermedad
{
    public class AgregarEnfermedadAuth : IAdminRequest<AgregarEnfermedadCommand, AgregarEnfermedadResponse>
    {
        private readonly IFitoReportDbContext db;
        private readonly IUserAccessor currentUser;

        public AgregarEnfermedadAuth(IFitoReportDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(AgregarEnfermedadCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
