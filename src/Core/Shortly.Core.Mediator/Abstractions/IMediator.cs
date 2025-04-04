namespace Shortly.Core.Mediator.Abstractions
{
    public interface IMediator
    {
        Task HandleAsync(IRequest request, CancellationToken cancellationToken = default);

        Task<TResponse> HandleAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);

        Task PublishAsync(INotification notification, CancellationToken cancellationToken = default);
    }
}
