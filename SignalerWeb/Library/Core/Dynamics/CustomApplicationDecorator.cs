using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Signaler.Library.Data.Core;
using Signaler.Library.Data.Repositories;
using Signaler.Library.Services;
using Signaler.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Signaler.Services.Library;
using Signaler.Services.assets;
using Signaler.Models.Assets;

namespace Signaler.Library.Core.Dynamics
{
    public static class CustomApplicationDecorator
    {
        public static void AddAllTypes<T>(this IServiceCollection services
            , Assembly[] assemblies
            , bool additionalRegisterTypesByThemself = false
            , ServiceLifetime lifetime = ServiceLifetime.Transient
            )
        {
            var typesFromAssemblies = assemblies.SelectMany(a =>
                a.DefinedTypes.Where(x => x.GetInterfaces().Any(i => i == typeof(T))));
            foreach (var type in typesFromAssemblies)
            {
                services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
                if (additionalRegisterTypesByThemself)
                    services.Add(new ServiceDescriptor(type, type, lifetime));
            }
        }

        public static void AddAllGenericTypes(this IServiceCollection services
            , Type t
            , Assembly[] assemblies
            , bool additionalRegisterTypesByThemself = false
            , ServiceLifetime lifetime = ServiceLifetime.Transient
        )
        {
            var genericType = t;
            var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == genericType)));

            foreach (var type in typesFromAssemblies)
            {
                services.Add(new ServiceDescriptor(t, type, lifetime));
                if (additionalRegisterTypesByThemself)
                    services.Add(new ServiceDescriptor(type, type, lifetime));
            }
        }



        public static IServiceCollection DecorateApplicationWithDefaultConfiguration(this IServiceCollection services, IConfiguration configuration)
        {


            //Inject the Business Context provider into the application
            services.AddDbContext<signalContext>(options =>
                options.UseSqlServer(
                    "Data Source=.;Initial Catalog=signalpro;Persist Security Info=True;User ID=signalpro;Password=1234567890;Encrypt=False;ApplicationIntent=ReadWrite;",
                    opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(30).TotalSeconds))
            );


            //Inject Data Services to the requested
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddSignalEntites(configuration);

            //Inject all signal services into the application service collection
            //services.AddScoped(typeof(IService<>), typeof(Service<,>));
            services.AddScoped(typeof(IService<assetViewModel>),typeof(assetService<assetViewModel>));
            //services.AddSignalBusinessServices(configuration, ServiceTargetType.Business, ServiceHostType.Web);

            //services.AddScoped<IDbContext, signalContext>();


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
