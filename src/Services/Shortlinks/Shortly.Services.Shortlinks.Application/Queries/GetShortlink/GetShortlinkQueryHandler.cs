using Microsoft.EntityFrameworkCore;
using Shortly.Core;
using Shortly.Core.Mapper.Abstractions;
using Shortly.Core.Mediator.Abstractions;
using Shortly.Services.Shortlinks.Api.Contracts.Responses;
using Shortly.Services.Shortlinks.Domain;
using Shortly.Services.Shortlinks.Repository.Abstractions;

namespace Shortly.Services.Shortlinks.Application.Queries.GetShortlink
{
    public class GetShortlinkQueryHandler : IRequestHandler<GetShortlinkQuery, ShortlinkResponse?>
    {
        protected readonly IShortlinksServiceRepository repository;
        protected readonly IMapper mapper;

        public GetShortlinkQueryHandler(IShortlinksServiceRepository repository, IMapper mapper)
        {
            this.repository = Guard.NotNull(repository);
            this.mapper = Guard.NotNull(mapper);
        }
        public async Task<ShortlinkResponse?> HandleAsync(GetShortlinkQuery request, CancellationToken cancellationToken = default)
        {
            Guard.NotNull(request);

            Shortlink? shortlink = await repository.ShortLinks.AsNoTracking().SingleOrDefaultAsync(shortlink => shortlink.Id == request.ShortlinkId, cancellationToken);

            return mapper.Map<Shortlink?, ShortlinkResponse?>(shortlink);
        }
    }
}
