using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Experimental;
using OnlineMarket.Application.Features.Authorization;
using OnlineMarket.Application.Intefaces;
using OnlineMarket.Infrastructure.Cache;
using OnlineMarket.Infrastructure.EFcore;
using OnlineMarket.Infrastructure.Implementations.Auth;
using OnlineMarket.Infrastructure.Implementations.Service;
using OnlineMarket.Infrastructure.Options;
using OnlineMarket.Infrastructure.Repositories;
using System.Net;
using System.Text;

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
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
           services.AddScoped<IAuthorizationHandler, PermissionsHandler>();

            return services;
        }
        public static void AddApiAuthentification(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection(nameof(JwtOptions))
        .Get<JwtOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) 
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters 
                    {
                        ValidateIssuer = false,      
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtOptions!.SecretKey))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["tasty-Cookies"];
                            return Task.CompletedTask;
                        }
                    };
                });
            services.AddAuthorization();
        }

    }
}
