using FitoReport.Application.Interfaces;
using FitoReport.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitoReport.Application.UseCases.Usuarios.Commands.AproveUsuario
{
    public class AproveUsuarioAuth : IAdminRequest<AproveUsuarioCommand, AproveUsuarioResponse>
    {
        private readonly IFitoReportDbContext db;
        private readonly IUserAccessor currentUser;

        public AproveUsuarioAuth(IFitoReportDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(AproveUsuarioCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
