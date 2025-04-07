using Microsoft.Extensions.DependencyInjection;
using Shortly.Core;
using Shortly.Core.Mapper.Extensions;
using Shortly.Core.Mediator.Extensions;
using Shortly.Services.Shortlinks.Api.Contracts.Responses;
using Shortly.Services.Shortlinks.Application.Mapping;
using Shortly.Services.Shortlinks.Domain;
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

            services.AddMapper();
            services.AddTypeMapper<ShortlinkResponseMapper, Shortlink, ShortlinkResponse>();

            return services;
        }
    }
}
