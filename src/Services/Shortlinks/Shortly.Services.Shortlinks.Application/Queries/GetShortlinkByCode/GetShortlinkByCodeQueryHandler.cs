using Microsoft.EntityFrameworkCore;
using Shortly.Core;
using Shortly.Core.Mapper.Abstractions;
using Shortly.Core.Mediator.Abstractions;
using Shortly.Services.Shortlinks.Api.Contracts.Responses;
using Shortly.Services.Shortlinks.Domain;
using Shortly.Services.Shortlinks.Repository.Abstractions;

namespace Shortly.Services.Shortlinks.Application.Queries.GetShortLinkByShortCode
{
    public class GetShortlinkByCodeQueryHandler : IRequestHandler<GetShortlinkByCodeQuery, ShortlinkResponse?>
    {
        protected readonly IShortlinksServiceRepository repository;
        protected readonly IMapper mapper;

        public GetShortlinkByCodeQueryHandler(IShortlinksServiceRepository repository)
        {
            this.repository = Guard.NotNull(repository);
            this.mapper = Guard.NotNull(mapper);
        }

        public async Task<ShortlinkResponse?> HandleAsync(GetShortlinkByCodeQuery request, CancellationToken cancellationToken = default)
        {
            Shortlink? shortlink = await repository.ShortLinks.AsNoTracking()
                .SingleOrDefaultAsync(p => p.ShortCode == request.ShortCode, cancellationToken);

            return mapper.Map<Shortlink?, ShortlinkResponse?>(shortlink);
        }
    }
}
