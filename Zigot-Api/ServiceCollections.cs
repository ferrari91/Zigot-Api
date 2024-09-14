using FluentValidation;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Server;
using MediatR;
using System.Reflection;
using Zigot.Core.Domain.Abstractions;
using Zigot_Api.Behaviours;
using Zigot_Api.Graph;
using Zigot_Api.Graph.Person;

namespace Zigot_Api.DependencyInjection
{
    public static class ServicesExtension
    {
        public static void AddServicesFeatures(this IServiceCollection services, IConfiguration configuration)
        {
            services.MediatorAddServices(configuration);
            services.GraphQLAddService();
            services.AutoMapperAddService();

            LoadAssembliesFromPath(AppDomain.CurrentDomain.BaseDirectory);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsSubclassOf(typeof(ServiceCollectionAbstraction)) && !t.IsAbstract);

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                if (instance is ServiceCollectionAbstraction featureExtension)
                    featureExtension.AddServices(services, configuration);
            }
        }

        private static void LoadAssembliesFromPath(string path)
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            var referencedPaths = Directory.GetFiles(path, "Zigot*.dll"); // Filtra apenas as DLLs com "Zigot" no nome

            foreach (var dllPath in referencedPaths)
            {
                var assemblyName = AssemblyName.GetAssemblyName(dllPath);
                if (!loadedAssemblies.Any(a => a.FullName == assemblyName.FullName))
                {
                    Assembly.Load(assemblyName);
                }
            }
        }

        private static void MediatorAddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient<IMediator, Mediator>();
        }

        private static void GraphQLAddService(this IServiceCollection services)
        {
            services.AddScoped<ZigotSchema>();

            services
                .AddGraphQL(options =>
                {
                    options.EnableMetrics = true;
                })
                .AddSystemTextJson()
                .AddErrorInfoProvider(x => x.ExposeExceptionStackTrace = true)
                .AddGraphTypes(typeof(ZigotSchema).Assembly)
                .AddDataLoader();
        }


        private static void AutoMapperAddService(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();

                foreach (var assembly in assemblies)
                {
                    cfg.AddMaps(assembly);
                }
            });
        }
    }
}
