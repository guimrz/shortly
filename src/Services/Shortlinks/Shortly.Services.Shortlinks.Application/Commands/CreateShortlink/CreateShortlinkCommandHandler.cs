using Microsoft.EntityFrameworkCore;
using Shortly.Core;
using Shortly.Core.Mapper.Abstractions;
using Shortly.Core.Mediator.Abstractions;
using Shortly.Services.Shortlinks.Api.Contracts.Responses;
using Shortly.Services.Shortlinks.Domain;
using Shortly.Services.Shortlinks.Repository.Abstractions;

namespace Shortly.Services.Shortlinks.Application.Commands.CreateShortLink
{
    public class CreateShortLinkCommandHandler : IRequestHandler<CreateShortLinkCommand, ShortlinkResponse>
    {
        protected readonly IShortlinksServiceRepository repository;
        protected readonly IMapper mapper;

        public CreateShortLinkCommandHandler(IShortlinksServiceRepository repository, IMapper mapper)
        {
            this.repository = Guard.NotNull(repository);
            this.mapper = Guard.NotNull(mapper);
        }

        public async Task<ShortlinkResponse> HandleAsync(CreateShortLinkCommand command, CancellationToken cancellationToken = default)
        {
            string shortCode;

            do
            {
                shortCode = Guid.NewGuid().ToString("N").Substring(0, 8);
            }
            while (await repository.ShortLinks.AnyAsync(shortlink => shortlink.ShortCode == shortCode, cancellationToken));

            Shortlink shortLink = new Shortlink(command.Request.Url, shortCode, TimeSpan.FromDays(30));

            shortLink = await repository.InsertAsync(shortLink, cancellationToken);
            await repository.SaveChangesAsync(cancellationToken);

            return mapper.Map<Shortlink, ShortlinkResponse>(shortLink);
        }
    }
}
