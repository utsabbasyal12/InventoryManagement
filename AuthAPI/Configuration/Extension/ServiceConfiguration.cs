using AuthAPI.Data;
using AuthAPI.Repositories.Implementation;
using AuthAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Configuration.Extension
{
    public static class ServiceConfiguration
    {
        internal static IServiceCollection AddCustomService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(item => item.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
