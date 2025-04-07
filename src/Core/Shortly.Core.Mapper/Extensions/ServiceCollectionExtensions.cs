using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shortly.Core.Mapper.Abstractions;

namespace Shortly.Core.Mapper.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            Guard.NotNull(services);

            services.TryAddScoped<IMapper, Mapper>();

            return services;
        }

        public static IServiceCollection AddTypeMapper<TTypeMapper, TSource, TDestination>(this IServiceCollection services)
            where TTypeMapper : class, ITypeMapper<TSource, TDestination>
        {
            Guard.NotNull(services);

            services.TryAddScoped<ITypeMapper<TSource, TDestination>, TTypeMapper>();

            return services;
        }
    }
}
