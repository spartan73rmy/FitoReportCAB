using Chikisistema.Persistence.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace Chikisistema.Persistence
{
    public class FitoReportDbContextFactory : DesignTimeDbContextFactoryBase<FitoReportDbContext>
    {
        protected override FitoReportDbContext CreateNewInstance(DbContextOptions<FitoReportDbContext> options)
        {
            return new FitoReportDbContext(options);
        }
    }
}
