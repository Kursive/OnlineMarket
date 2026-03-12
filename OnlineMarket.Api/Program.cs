using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using OnlineMarket.Api.Validators;
using OnlineMarket.Application.Features.Order.Commands.CreateOrder;
using OnlineMarket.Infrastructure.Extension;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddValidatorsFromAssemblyContaining<OrderCreateDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UserCreateDtoValidator>();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateOrderHandler).Assembly));

//builder.Services.AddMemoryCache(options => // кэширование 
//{
//    options.SizeLimit = 1000; 
//});
//var options = new MemoryCacheEntryOptions()
//    .SetSize(1);

//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    options.Configuration = "redis-10867.c304.europe-west1-2.gce.cloud.redislabs.com:10867,password=UQibp3eS6KEPxqZamqRB0R7LmGZExTqG";
//    options.InstanceName = "OnlineMarket_";
//});

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

app.UseAuthorization();

app.MapControllers();

app.Run();
