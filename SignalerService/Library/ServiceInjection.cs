using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Linq;
using Signaler.Services.Library;

namespace Signaler.Library.Services
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddSignalBusinessServices(this IServiceCollection services, IConfiguration configuration, ServiceTargetType targetType, ServiceHostType hostType)
        {
            var types = typeof(ServiceModelBase).Assembly
                .GetTypes()
                .Where(item => ((item.GetCustomAttribute<ServiceHost>() != null) && item.GetCustomAttribute<ServiceHost>().Type == hostType) &&
                ((item.GetCustomAttribute<ServiceTarget>() != null) && item.GetCustomAttribute<ServiceTarget>().Target == targetType) &&
                item.GetInterfaces()
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
