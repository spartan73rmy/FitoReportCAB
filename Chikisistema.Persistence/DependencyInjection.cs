using Chikisistema.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;

namespace Chikisistema.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext using SQL Server Provider
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                services.AddDbContext<ChikisistemaDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("FitoReportDatabase")));
            }
            else
            {
                services.AddDbContext<ChikisistemaDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("FitoReportDatabaseLinux")));
            }
            services.AddScoped<IFitoReportDbContext>(provider => provider.GetService<ChikisistemaDbContext>());
            return services;
        }
    }
}
