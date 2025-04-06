using Microsoft.Extensions.DependencyInjection;
using Shortly.Core;
using Shortly.Core.Mediator.Extensions;
using System.Reflection;

namespace Shortly.Services.Shortlinks.Application.Extensions
{
    /// <summary>
    /// Defines extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddShortlinksServiceApplication(this IServiceCollection services)
        {
            Guard.NotNull(services);

            services.AddMediator();
            services.RegisterHandlersFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
