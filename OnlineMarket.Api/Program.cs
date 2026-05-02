using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Models;
using OnlineMarket.Api.Validators;
using OnlineMarket.Application.Features.Order.Commands.CreateOrder;
using OnlineMarket.Infrastructure.Extension;
using OnlineMarket.Infrastructure.Implementations.Service;
using OnlineMarket.Infrastructure.Options;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddValidatorsFromAssemblyContaining<OrderCreateDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UserCreateDtoValidator>();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApiAuthentification(builder.Configuration);
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.Configure<RolePermissionsOptions>(builder.Configuration.GetSection("RolePermissions"));
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateOrderHandler).Assembly));


builder.Services.AddMemoryCache(options => 
{
    options.SizeLimit = 1000;
});
var options = new MemoryCacheEntryOptions()
    .SetSize(1);
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "127.0.0.1:6379";
    options.InstanceName = "OnlineMarket_";
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
