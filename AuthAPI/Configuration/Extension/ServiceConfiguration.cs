using AuthAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Configuration.Extension
{
    public static class ServiceConfiguration
    {
        internal static IServiceCollection AddCustomService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(item => item.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
