using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Linq;
using Signaler.Library.Data.Repositories;

namespace Signaler.Library.Data.Core
{
    public static class DataInjection
    {
        public static IServiceCollection AddSignalEntites(this IServiceCollection services, IConfiguration configuration)
        {
            var types = typeof(BaseEntity).Assembly
                .GetTypes()
                .Where(item => item.GetInterfaces()
                .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IRepository<>)) && !item.IsAbstract && !item.IsInterface)
                .ToList();

            foreach (var assignedTypes in types)
            {
                var repoType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IRepository<>));
                services.AddScoped(repoType, assignedTypes);
            }

            return services;
        }
    }
}
