using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shortly.Core.Mediator.Abstractions;
using System.Reflection;

namespace Shortly.Core.Mediator.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            Guard.NotNull(services);

            services.TryAddScoped<IMediator, Mediator>();

            return services;
        }

        public static IServiceCollection RegisterHandlersFromCurrentAssembly(this IServiceCollection services)
        {
            return services.RegisterHandlersFromAssembly(Assembly.GetCallingAssembly());
        }

        public static IServiceCollection RegisterHandlersFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            Guard.NotNull(services);
            Guard.NotNull(assembly);

            services.RegisterAssemblyTypesImplementing(assembly, typeof(IRequestHandler<,>));
            services.RegisterAssemblyTypesImplementing(assembly, typeof(IRequestHandler<>));
            services.RegisterAssemblyTypesImplementing(assembly, typeof(INotificationHandler<>));

            return services;
        }

        private static IServiceCollection RegisterAssemblyTypesImplementing(this IServiceCollection services, Assembly assembly, Type type)
        {
            Guard.NotNull(type);
            Guard.NotNull(assembly);

            if (!type.IsInterface || !type.IsGenericTypeDefinition)
            {
                throw new ArgumentException("The specified type must be a generic interface", nameof(type));
            }

            var implementationTypes = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && !t.IsGenericTypeDefinition)
                .Where(t => t.GetInterfaces()
                             .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == type));

            foreach (var implType in implementationTypes)
            {
                var interfaces = implType.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == type);

                foreach (var interfaceType in interfaces)
                {
                    services.Add(new ServiceDescriptor(interfaceType, implType, ServiceLifetime.Scoped));
                }
            }

            return services;
        }
    }
}
