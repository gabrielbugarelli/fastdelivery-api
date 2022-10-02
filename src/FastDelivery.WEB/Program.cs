using FastDelivery.Application.Services.ProductHandler;
using FastDelivery.Core.Mediatr;
using FastDelivery.Domain.Interfaces.Repositories;
using FastDelivery.Infrastructure.Contexts;
using FastDelivery.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//database provider configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseNpgsql(builder.Configuration.GetConnectionString("FastDeliveryConnection"));
});

// Mediatr configuration
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddScoped<IMediatrHandler, MediatrHandler>();
builder.Services.AddScoped<IRequestHandler<CreateProductCommand, bool>, ProductCommandHandler>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
