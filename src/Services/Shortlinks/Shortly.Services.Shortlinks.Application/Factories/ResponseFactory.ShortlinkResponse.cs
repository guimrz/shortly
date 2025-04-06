using Shortly.Services.Shortlinks.Api.Contracts.Responses;
using Shortly.Services.Shortlinks.Domain;
using System.Diagnostics.CodeAnalysis;

namespace Shortly.Services.Shortlinks.Application.Factories
{
    public static partial class ResponseFactory
    {
        [return: NotNullIfNotNull("shortlink")]
        public static ShortlinkResponse? Create(Shortlink? shortlink)
        {
            if (shortlink is null)
            {
                return null;
            }
            else
            {
                return new ShortlinkResponse
                {
                    CreationDate = shortlink.CreationDate,
                    ExpirationDate = shortlink.ExpirationDate,
                    Id = shortlink.Id,
                    OriginalUrl = shortlink.OriginalUrl,
                    ShortCode = shortlink.ShortCode,
                    ShortUrl = $"http://short.ly/{shortlink.ShortCode}"
                };
            }
        }
    }
}
