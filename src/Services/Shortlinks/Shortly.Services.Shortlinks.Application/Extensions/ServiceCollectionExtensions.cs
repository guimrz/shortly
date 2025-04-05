using Microsoft.Extensions.DependencyInjection;
using Shortly.Core;
using Shortly.Core.Mediator.Extensions;
using Shortly.Services.Shortlinks.Api.Contracts.Responses;
using Shortly.Services.Shortlinks.Application.Commands.CreateShortLink;
using Shortly.Services.Shortlinks.Application.Queries.GetShortlink;
using Shortly.Services.Shortlinks.Application.Queries.GetShortLinkByShortCode;

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
            services.AddRequestHandler<CreateShortLinkCommandHandler, CreateShortLinkCommand, ShortlinkResponse>();
            services.AddRequestHandler<GetShortlinkByCodeQueryHandler, GetShortlinkByCodeQuery, ShortlinkResponse?>();
            services.AddRequestHandler<GetShortlinkQueryHandler, GetShortlinkQuery, ShortlinkResponse?>();

            return services;
        }
    }
}
