using Shortly.Core.Mediator.Abstractions;
using Shortly.Services.Shortlinks.Api.Contracts.Requests;
using Shortly.Services.Shortlinks.Api.Contracts.Responses;

namespace Shortly.Services.Shortlinks.Application.Commands.CreateShortLink
{
    public class CreateShortLinkCommand(CreateShortlinkRequest request) : IRequest<ShortlinkResponse>
    {
        public CreateShortlinkRequest Request { get; init; } = request;
    }
}
