using Chikisistema.Persistence.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace Chikisistema.Persistence
{
    public class ChikisistemaDbContextFactory : DesignTimeDbContextFactoryBase<ChikisistemaDbContext>
    {
        protected override ChikisistemaDbContext CreateNewInstance(DbContextOptions<ChikisistemaDbContext> options)
        {
            return new ChikisistemaDbContext(options);
        }
    }
}
