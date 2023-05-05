
using AutoMapper;

using BatteryMonitorApp.Contracts.MapperConfigs;
using BatteryMonitorApp.Domain.DbContexts;
using BatteryMonitorApp.Domain.Repositories;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Get Sql Connect String
var connectionString = builder.Configuration.GetConnectionString("SqlConnection") ??
    throw new InvalidOperationException("Connection string 'SqlConnection' not found.");

builder.Services.AddDbContext<BatteryMonitorContext>(c => c.UseSqlServer(connectionString));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSingleton(_ =>
{
    MapperConfiguration mc = new(cfg => cfg.AddProfile<MapperConfigProfiles>());
    return mc.CreateMapper();
}
);
//builder.Services.AddDomain();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

public partial class Program { }