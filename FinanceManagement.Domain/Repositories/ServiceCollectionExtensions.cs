using Microsoft.Extensions.DependencyInjection;

using FinanceManagement.Domain.Helpers;
using FinanceManagement.Domain.Repositories;
using AccountingManagement.Domain.Commands;

namespace FinanceManagement.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IIdentifierGenerator, IdentifierGenerator>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(CreateAccountingCommand).Assembly)); 

            return services;
        }
    }
}