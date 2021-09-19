using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Linq;

namespace Signaler.Library.Services
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddSignalServices(this IServiceCollection services, IConfiguration configuration)
        {
            var types = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(item => item.GetInterfaces()
                .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IService<>)) && !item.IsAbstract && !item.IsInterface)
                .ToList();

            foreach (var assignedTypes in types)
            {
                var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IService<>));
                services.AddScoped(serviceType, assignedTypes);
            }

            return services;
        }
    }
}
