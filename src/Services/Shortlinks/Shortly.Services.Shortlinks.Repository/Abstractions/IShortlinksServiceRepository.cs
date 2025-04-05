using Shortly.Services.Shortlinks.Domain;

namespace Shortly.Services.Shortlinks.Repository.Abstractions
{
    public interface IShortlinksServiceRepository
    {
        IQueryable<Shortlink> ShortLinks { get; }

        Task<Shortlink> InsertAsync(Shortlink shortLink, CancellationToken cancellationToken = default);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
