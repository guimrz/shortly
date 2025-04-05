namespace Shortly.Services.Shortlinks.Api.Contracts.Responses
{
    public record ShortlinkResponse
    {
        public Guid Id { get; set; }

        public string OriginalUrl { get; set; } = default!;

        public string? Alias { get; set; }

        public string ShortUrl { get; set; } = default!;

        public string ShortCode { get; set; } = default!;

        public DateTimeOffset CreationDate { get; set; }

        public DateTimeOffset? ExpirationDate { get; set; }
    }
}
