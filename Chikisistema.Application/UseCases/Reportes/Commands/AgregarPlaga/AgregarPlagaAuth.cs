using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chikisistema.Application.UseCases.Reportes.Commands.AgregarPlaga
{
    public class AgregarPlagaAuth : IAuthenticatedRequest<AgregarPlagaCommand, AgregarPlagaResponse>
    {
        private readonly IChikisistemaDbContext db;
        private readonly IUserAccessor currentUser;

        public AgregarPlagaAuth(IChikisistemaDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }
        
        public Task Validate(AgregarPlagaCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
