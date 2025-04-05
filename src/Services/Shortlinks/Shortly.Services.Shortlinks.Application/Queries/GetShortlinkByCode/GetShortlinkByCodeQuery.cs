using Shortly.Core.Mediator.Abstractions;
using Shortly.Services.Shortlinks.Api.Contracts.Responses;

namespace Shortly.Services.Shortlinks.Application.Queries.GetShortLinkByShortCode
{
    public class GetShortlinkByCodeQuery(string shortCode) : IRequest<ShortlinkResponse?>
    {
        public string ShortCode { get; init; } = shortCode; 
    }
}
