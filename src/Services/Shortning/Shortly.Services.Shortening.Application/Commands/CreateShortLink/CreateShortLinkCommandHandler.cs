using Shortly.Core.Mediator.Abstractions;

namespace Shortly.Services.Shortening.Application.Commands.CreateShortLink
{
    public class CreateShortLinkCommandHandler : IRequestHandler<CreateShortLinkCommand, object>
    {
        public Task<object> HandleAsync(CreateShortLinkCommand request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
