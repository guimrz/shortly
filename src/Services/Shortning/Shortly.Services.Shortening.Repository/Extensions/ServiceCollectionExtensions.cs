using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shortly.Services.Shortening.Repository.Abstractions;

namespace Shortly.Services.Shortening.Repository.Extensions
{
    /// <summary>
    /// Defines extensions for <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddShorteningServiceRepository(this IServiceCollection serviceCollection)
        {
            ArgumentNullException.ThrowIfNull(serviceCollection);

            serviceCollection.AddDbContext<ShorteningServiceDbContext>();
            serviceCollection.TryAddScoped<IShorteningServiceRepository, ShorteningServiceRepository>();

            return serviceCollection;
        }
    }
}
