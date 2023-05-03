using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatteryMonitorApp.UnitTests.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace BatteryMonitorApp.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            _ = services.AddMediatR(c => c.RegisterServicesFromAssembly(
                typeof(Commands.BatteryDataCommand).Assembly));
            return services;
        }
    }
}
