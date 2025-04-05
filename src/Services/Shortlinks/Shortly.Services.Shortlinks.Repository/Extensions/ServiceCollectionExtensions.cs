using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shortly.Core;
using Shortly.Services.Shortlinks.Repository.Abstractions;

namespace Shortly.Services.Shortlinks.Repository.Extensions
{
    /// <summary>
    /// Defines extensions for <see cref="IServiceCollection"/>
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddShortlinksServiceRepository(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            Guard.NotNull(serviceCollection);

            serviceCollection.AddDbContext<ShortlinksServiceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            serviceCollection.TryAddScoped<IShortlinksServiceRepository, ShortlinksServiceRepository>();

            return serviceCollection;
        }
    }
}