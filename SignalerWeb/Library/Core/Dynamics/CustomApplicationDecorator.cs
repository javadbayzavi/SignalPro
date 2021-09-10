using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Signaler.Services.Core;
using Signaler.Data.Core;
using Signaler.Data.Repositories;

namespace Signaler.Library.Core.Dynamics
{
    public static class CustomApplicationDecorator
    {
        public static IServiceCollection DecorateApplicationWithDefaultConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<sin>

            //Inject the Business Context provider into the application
            services.AddSingleton(typeof(IDbContext));

            //Inject the Business Data provider into the application
            services.AddSingleton(typeof(IRepository<>));

            //Inject the Business service provider into the application
            services.AddSingleton(typeof(IService<>));

            //Inject Data Services to the requested
            //services.AddScoped<IService<BaseEntity>, Service<BaseEntity>>();
            services.AddScoped<IService<BaseEntity>>(srv => new Service<BaseEntity>(srv.GetRequiredService<IRepository<BaseEntity>>()));

            //Configure MVC service to load generic types based on requested business action
            services.AddMvc(
                o => o.Conventions.Add(
                    new GenericControllerRouteConvention()
                    )
                )
                .ConfigureApplicationPartManager(m =>
                    m.FeatureProviders.Add(new GenericTypeControllerFeatureProvider())
                );

            return services;
        }
    }
}
