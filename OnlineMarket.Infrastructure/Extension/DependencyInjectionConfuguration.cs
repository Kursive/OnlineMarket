using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineMarket.Application.Intefaces;
using OnlineMarket.Infrastructure.Cache;
using OnlineMarket.Infrastructure.EFcore;
using OnlineMarket.Infrastructure.Repositories;

namespace OnlineMarket.Infrastructure.Extension
{
   public static class DependencyInjectionConfuguration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("Postgres")));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<UsersCache>();

            return services;
        }
    }
}
