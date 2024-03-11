using Calculator.API.Domain.Contexts;
using Calculator.API.Domain.Repositories;
using Calculator.API.Repositories;
using Calculator.API.Services;
using Calculator.API.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<ICalculatorValueRepository, CalculatorValueRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICalculatorValueService, CalculatorValueService>();
builder.Services.AddScoped<IPositionService, PositionService>();

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

app.UseCors(builder => 
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

using AppDbContext appDbContext = new AppDbContext();
appDbContext.EnsureDatabaseCreated();

app.Run();
