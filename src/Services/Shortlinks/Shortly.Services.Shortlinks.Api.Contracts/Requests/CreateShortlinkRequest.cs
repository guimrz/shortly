namespace Shortly.Services.Shortlinks.Api.Contracts.Requests
{
    public class CreateShortlinkRequest
    {
        public string Url { get; set; } = default!;

        public string? Alias { get; set; }
    }
}
