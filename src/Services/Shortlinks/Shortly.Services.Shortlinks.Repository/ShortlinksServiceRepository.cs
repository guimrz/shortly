using Shortly.Core;
using Shortly.Services.Shortlinks.Domain;
using Shortly.Services.Shortlinks.Repository.Abstractions;

namespace Shortly.Services.Shortlinks.Repository
{
    public class ShortlinksServiceRepository : IShortlinksServiceRepository
    {
        protected readonly ShortlinksServiceDbContext context;

        public IQueryable<Shortlink> ShortLinks => context.Set<Shortlink>();

        public ShortlinksServiceRepository(ShortlinksServiceDbContext context)
        {
            this.context = Guard.NotNull(context);
        }

        public async Task<Shortlink> InsertAsync(Shortlink shortLink, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(shortLink);

            cancellationToken.ThrowIfCancellationRequested();

            var entry = await context.AddAsync(shortLink, cancellationToken);

            return entry.Entity;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
