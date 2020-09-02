using Chikisistema.Domain.Entities;
using Chikisistema.Infraestructure;
using Chikisistema.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace Chikisistema.Application.Tests.Infraestructure
{
    public class ChikisistemaDbContextFactory
    {
        public static FitoReportDbContext Create()
        {
            var options = new DbContextOptionsBuilder<FitoReportDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new FitoReportDbContext(options, new MachineDateTime());

            context.Database.EnsureCreated();
            context.Usuario.AddRange(new[] {
                new Usuario { Id = 1, NombreUsuario = "Admin", TipoUsuario = Domain.Enums.TiposUsuario.Admin, Email = "asd@asd.com"},
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(FitoReportDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
