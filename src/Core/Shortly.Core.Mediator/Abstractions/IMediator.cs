namespace Shortly.Core.Mediator.Abstractions
{
    public interface IMediator
    {
        Task HandleAsync<TRequest>(TRequest request, CancellationToken cancellationToken = default) 
            where TRequest : IRequest;

        Task<TResponse> HandleAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
            where TRequest : IRequest<TResponse>;

        Task PublishAsync<TNotification>(TNotification notification, CancellationToken cancellationToken = default) 
            where TNotification : INotification;
    }
}
