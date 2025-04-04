namespace Shortly.Services.Shortening.Domain
{
    public class ShortLink
    {
        public Guid Id { get; protected set; }

        public Guid TenantId { get; protected set; }

        public string OriginalUrl { get; protected set; }

        public string ShortCode { get; protected set; }

        public string? Alias { get; protected set; }

        public DateTimeOffset CreationDate { get; protected set; }

        public DateTimeOffset? ExpirationDate { get; protected set; }

        public ShortLink(Guid tenantId, string originalUrl, string shortCode, string? alias, TimeSpan timeToLive)
        {
            ArgumentException.ThrowIfNullOrEmpty(originalUrl);
            ArgumentException.ThrowIfNullOrEmpty(shortCode);

            TenantId = tenantId;
            OriginalUrl = originalUrl;
            ShortCode = shortCode;
            Alias = alias;
            CreationDate = DateTime.UtcNow;
            ExpirationDate = CreationDate.Add(timeToLive);
        }
    }
}
