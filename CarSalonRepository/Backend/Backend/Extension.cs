using Backend.Repositories;
using Backend.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Backend
{
    public static class DatabaseServiceExtensions
    {
        public static IServiceCollection AddDatabesServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                })
            );
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ISalonRepository, SalonRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
