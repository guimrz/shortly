using Shortly.Core.Mapper.Abstractions;
using Shortly.Services.Shortlinks.Api.Contracts.Responses;
using Shortly.Services.Shortlinks.Domain;

namespace Shortly.Services.Shortlinks.Application.Mapping
{
    public class ShortlinkResponseMapper : ITypeMapper<Shortlink, ShortlinkResponse>
    {
        public ShortlinkResponse Map(Shortlink source)
        {
            return new ShortlinkResponse
            {
                CreationDate = source.CreationDate,
                ExpirationDate = source.ExpirationDate,
                Id = source.Id,
                OriginalUrl = source.OriginalUrl,
                ShortCode = source.ShortCode,
                ShortUrl = $"http://short.ly/{source.ShortCode}"
            };
        }
    }
}
