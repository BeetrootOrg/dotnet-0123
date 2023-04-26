using AutoMapper;

using Microsoft.Extensions.DependencyInjection;

using TaskManagement.Domain.Commands;
using TaskManagement.Domain.Helpers;
using TaskManagement.Domain.Profiles;
using TaskManagement.Domain.Repositories;

namespace TaskManagement.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            _ = services.AddScoped<IRepository, Repository>();
            _ = services.AddScoped<IIdentifierGenerator, IdentifierGenerator>();
            _ = services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            _ = services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(CreateTaskCommand).Assembly));
            _ = services.AddSingleton(_ =>
            {
                MapperConfiguration mc = new(cfg => cfg.AddProfile<TaskManagementProfile>());
                return mc.CreateMapper();
            });

            return services;
        }
    }
}