using Microsoft.Extensions.DependencyInjection;
using Shortly.Core.Mediator.Extensions;

namespace Shortly.Services.Shortening.Application.Extensions
{
    /// <summary>
    /// Defines extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddShorteningServiceApplication(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddMediator();

            return services;
        }
    }
}
