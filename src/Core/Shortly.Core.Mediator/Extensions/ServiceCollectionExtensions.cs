using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shortly.Core.Mediator.Abstractions;

namespace Shortly.Core.Mediator.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.TryAddScoped<IMediator, Mediator>();

            return services;
        }

        public static IServiceCollection AddRequestHandler<THandler, TRequest, TResponse>(this IServiceCollection services)
            where THandler : class, IRequestHandler<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddScoped<IRequestHandler<TRequest, TResponse>, THandler>();

            return services;
        }

        public static IServiceCollection AddRequestHandler<THandler, TRequest>(this IServiceCollection services)
            where THandler : class, IRequestHandler<TRequest>
            where TRequest : IRequest
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddScoped<IRequestHandler<TRequest>, THandler>();

            return services;
        }

        public static IServiceCollection AddNotificationHandler<THandler, TNotification>(this IServiceCollection services)
            where THandler : class, INotificationHandler<TNotification>
            where TNotification : INotification
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddScoped<INotificationHandler<TNotification>, THandler>();

            return services;
        }
    }
}
