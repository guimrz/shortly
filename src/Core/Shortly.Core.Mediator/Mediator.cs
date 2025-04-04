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
            Guard.NotNull(serviceProvider);
            Guard.NotNull(logger);

            this.logger = logger;
            this.serviceProvider = serviceProvider;
        }

        public async Task HandleAsync<TRequest>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest
        {
            Guard.NotNull(request);

            IRequestHandler<IRequest>? handler = serviceProvider.GetService<IRequestHandler<IRequest>>();

            if (handler is null)
            {
                throw new InvalidOperationException($"Could not retrieve the handler for the request of type '{request.GetType().FullName}'.");
            }

            await handler.HandleAsync(request, cancellationToken);
        }

        public async Task<TResponse> HandleAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest<TResponse>
        {
            Guard.NotNull(request);


            IRequestHandler<TRequest, TResponse>? handler = serviceProvider.GetService<IRequestHandler<TRequest, TResponse>>();

            if (handler is null)
            {
                throw new InvalidOperationException($"Could not retrieve the handler for the request of type '{request.GetType().FullName}'.");
            }

            return await handler.HandleAsync(request, cancellationToken);
        }

        public Task PublishAsync<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification
        {
            Guard.NotNull(notification);

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
