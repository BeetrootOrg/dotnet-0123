using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SimpleServer.Context;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PersonDbContext>(options => options.UseInMemoryDatabase("PersonDbContext"));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.MapControllers();

await app.RunAsync();