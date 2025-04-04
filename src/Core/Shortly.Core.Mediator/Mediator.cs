using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shortly.Core.Mediator.Abstractions;

namespace Shortly.Core.Mediator
{
    public class Mediator : IMediator
    {
        protected readonly ILogger logger;
        protected readonly IServiceProvider serviceProvider;

        public Mediator(ILogger<Mediator> logger, IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider);
            ArgumentNullException.ThrowIfNull(logger);

            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        public async Task HandleAsync(IRequest request, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(request);

            IRequestHandler<IRequest>? handler = serviceProvider.GetService<IRequestHandler<IRequest>>();

            if (handler is null)
            {
                throw new InvalidOperationException($"Could not retrieve the handler for the request of type '{request.GetType().FullName}'.");
            }

            await handler.HandleAsync(request, cancellationToken);
        }

        public async Task<TResponse> HandleAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(request);

            IRequestHandler<IRequest<TResponse>, TResponse>? handler = serviceProvider.GetService<IRequestHandler<IRequest<TResponse>, TResponse>>();

            if (handler is null)
            {
                throw new InvalidOperationException($"Could not retrieve the handler for the request of type '{request.GetType().FullName}'.");
            }

            return await handler.HandleAsync(request, cancellationToken);
        }

        public Task PublishAsync(INotification notification, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(notification);

            IEnumerable<INotificationHandler<INotification>> handlers = serviceProvider.GetServices<INotificationHandler<INotification>>();

            if (handlers is null || !handlers.Any())
            {
                logger.LogWarning($"Could not find any handler for the notification of type: '{notification.GetType().FullName}'.");
            }
            else
            {
                cancellationToken.ThrowIfCancellationRequested();

                foreach (var handler in handlers)
                {
                    _ = handler.HandleAsync(notification);
                }
            }

            return Task.CompletedTask;
        }
    }
}
