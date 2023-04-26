using System;
using System.IO;
using System.Reflection;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using TaskManagement.Api;
using TaskManagement.Domain;
using TaskManagement.Domain.DbContexts;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Task Management API",
        Description = "An ASP.NET Core Web API for managing tasks"
    });

    string xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddOptions<TaskManagementOptions>()
    .Bind(builder.Configuration);

builder.Services.AddDomain();
builder.Services.AddDbContext<TaskManagementContext>(
    (IServiceProvider sp, DbContextOptionsBuilder c) =>
    {
        IOptionsMonitor<TaskManagementOptions> options = sp.GetRequiredService<IOptionsMonitor<TaskManagementOptions>>();
        _ = c.UseNpgsql(options.CurrentValue.TaskManagementConnectionString);
    });

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

public partial class Program { }