using Shortly.Services.Shortening.Domain;
using Shortly.Services.Shortening.Repository.Abstractions;

namespace Shortly.Services.Shortening.Repository
{
    public class ShorteningServiceRepository : IShorteningServiceRepository
    {
        protected readonly ShorteningServiceDbContext Context;

        public IQueryable<ShortLink> ShortLinks => Context.Set<ShortLink>();

        public ShorteningServiceRepository(ShorteningServiceDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            Context = context;
        }

        public async Task<ShortLink> InsertAsync(ShortLink shortLink, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var entry = await Context.AddAsync(shortLink, cancellationToken);

            return entry.Entity;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await Context.SaveChangesAsync(cancellationToken);
        }
    }
}
