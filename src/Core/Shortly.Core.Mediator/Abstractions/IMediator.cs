namespace Shortly.Core.Mediator.Abstractions
{
    public interface IMediator
    {
        Task HandleAsync<TRequest>(TRequest request, CancellationToken cancellationToken = default) 
            where TRequest : IRequest;

        Task<TResponse> HandleAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);

        Task PublishAsync<TNotification>(TNotification notification, CancellationToken cancellationToken = default) 
            where TNotification : INotification;
    }
}
