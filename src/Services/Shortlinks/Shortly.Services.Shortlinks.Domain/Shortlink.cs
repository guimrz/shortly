namespace Shortly.Services.Shortlinks.Domain
{
    public class Shortlink
    {
        public Guid Id { get; protected set; }

        public string OriginalUrl { get; protected set; }

        public string ShortCode { get; protected set; }

        public DateTimeOffset CreationDate { get; protected set; }

        public DateTimeOffset? ExpirationDate { get; protected set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        protected Shortlink()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            //
        }

        public Shortlink(string originalUrl, string shortCode, TimeSpan timeToLive)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(originalUrl);
            ArgumentException.ThrowIfNullOrWhiteSpace(shortCode);

            OriginalUrl = originalUrl;
            ShortCode = shortCode;
            CreationDate = DateTime.UtcNow;
            ExpirationDate = CreationDate.Add(timeToLive);
        }
    }
}
