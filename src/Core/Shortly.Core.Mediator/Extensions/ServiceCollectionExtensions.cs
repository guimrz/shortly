using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shortly.Core.Mediator.Abstractions;

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

        public static IServiceCollection AddRequestHandler<THandler, TRequest, TResponse>(this IServiceCollection services)
            where THandler : class, IRequestHandler<TRequest, TResponse>
            where TRequest : class, IRequest<TResponse>
        {
            Guard.NotNull(services);

            services.AddScoped<IRequestHandler<TRequest, TResponse>, THandler>();

            return services;
        }

        public static IServiceCollection AddRequestHandler<THandler, TRequest>(this IServiceCollection services)
            where THandler : class, IRequestHandler<TRequest>
            where TRequest : IRequest
        {
            Guard.NotNull(services);

            services.AddScoped<IRequestHandler<TRequest>, THandler>();

            return services;
        }

        public static IServiceCollection AddNotificationHandler<THandler, TNotification>(this IServiceCollection services)
            where THandler : class, INotificationHandler<TNotification>
            where TNotification : INotification
        {
            Guard.NotNull(services);

            services.AddScoped<INotificationHandler<TNotification>, THandler>();

            return services;
        }
    }
}
