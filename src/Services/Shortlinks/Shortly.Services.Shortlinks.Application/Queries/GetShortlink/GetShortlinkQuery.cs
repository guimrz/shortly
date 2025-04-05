using Shortly.Core.Mediator.Abstractions;
using Shortly.Services.Shortlinks.Api.Contracts.Responses;

namespace Shortly.Services.Shortlinks.Application.Queries.GetShortlink
{
    public class GetShortlinkQuery(Guid shortlinkId) : IRequest<ShortlinkResponse?>
    {
        public Guid ShortlinkId { get; init; } = shortlinkId;
    }
}
