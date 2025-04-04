using Shortly.Services.Shortening.Domain;

namespace Shortly.Services.Shortening.Repository.Abstractions
{
    public interface IShorteningServiceRepository
    {
        IQueryable<ShortLink> ShortLinks { get; }

        Task<ShortLink> InsertAsync(ShortLink shortLink, CancellationToken cancellationToken = default);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
