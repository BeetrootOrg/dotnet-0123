using AccountingManagement.Domain.Commands;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using FluentValidation;
using FinanceManagement.Api.Validators;

using FinanceManagement.Domain;
using FinanceManagement.Context.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;
using FinanceManagement.Api;
using Microsoft.Extensions.Options;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Finance Management API",
        Description = "An ASP.NET Core Web API for managing your finances"
    });
    string xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});



builder.Services.AddOptions<FinanceManagementOptions>()
    .Bind(builder.Configuration);

builder.Services.AddDomain();
builder.Services.AddDbContext<FinanceManagementContext>(
    (IServiceProvider sp, DbContextOptionsBuilder c) =>
    {
        IOptionsMonitor<FinanceManagementOptions> options = sp.GetRequiredService<IOptionsMonitor<FinanceManagementOptions>>();
        _ = c.UseNpgsql(options.CurrentValue.FinanceManagementConnectionString);
    });

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateAccountingValueValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateAccountingRequestValidator>();


builder.Services
    .AddHealthChecks()
    .AddNpgSql(
        sp =>
        {
            IOptionsMonitor<FinanceManagementOptions> options = sp.GetRequiredService<IOptionsMonitor<FinanceManagementOptions>>();
            return options.CurrentValue.FinanceManagementConnectionString;
        },
        timeout: TimeSpan.FromSeconds(1)
    );



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();

public partial class Program {}