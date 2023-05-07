using System;
using System.IO;
using System.Reflection;

using AutoMapper;

using BatteryMonitorApp.Contracts.MapperConfigs;
using BatteryMonitorApp.Domain.DbContexts;
using BatteryMonitorApp.Domain.Repositories;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Battery Monitor API",
        Description = "An ASP.NET Core Web API for managing battery"
    });
    string xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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
builder.Services.AddHealthChecks().AddSqlServer(connectionString, timeout: TimeSpan.FromSeconds(1));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapHealthChecks("/helth");

app.Run();

public partial class Program { }