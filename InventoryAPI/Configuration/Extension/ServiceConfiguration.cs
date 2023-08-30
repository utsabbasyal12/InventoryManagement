using InventoryManagement.DataAccess.Context;
using InventoryManagement.DataAccess.Implementation;
using InventoryManagement.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace InventoryAPI.Configuration.Extension
{
    public static class ServiceConfiguration
    {
        public static void AddCustomService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<InventoryManagementDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Inventory API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement{{
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
                new string[]{}
                    }
                });
            });
        }
    }
}
