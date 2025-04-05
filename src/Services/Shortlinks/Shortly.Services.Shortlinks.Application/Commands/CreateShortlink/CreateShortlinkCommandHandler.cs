using Microsoft.EntityFrameworkCore;
using Shortly.Core;
using Shortly.Core.Mediator.Abstractions;
using Shortly.Services.Shortlinks.Api.Contracts.Responses;
using Shortly.Services.Shortlinks.Application.Factories;
using Shortly.Services.Shortlinks.Domain;
using Shortly.Services.Shortlinks.Repository.Abstractions;

namespace Shortly.Services.Shortlinks.Application.Commands.CreateShortLink
{
    public class CreateShortLinkCommandHandler : IRequestHandler<CreateShortLinkCommand, ShortlinkResponse>
    {
        protected readonly IShortlinksServiceRepository repository;

        public CreateShortLinkCommandHandler(IShortlinksServiceRepository repository)
        {
            this.repository = Guard.NotNull(repository);
        }

        public async Task<ShortlinkResponse> HandleAsync(CreateShortLinkCommand command, CancellationToken cancellationToken = default)
        {
            string shortCode;

            do
            {
                shortCode = Guid.NewGuid().ToString("N").Substring(0, 8);
            }
            while (await repository.ShortLinks.AnyAsync(shortlink => shortlink.ShortCode == shortCode, cancellationToken));

            Shortlink shortLink = new Shortlink(command.Request.Url, shortCode, command.Request.Alias, TimeSpan.FromDays(30));

            shortLink = await repository.InsertAsync(shortLink, cancellationToken);
            await repository.SaveChangesAsync(cancellationToken);

            return ResponseFactory.Create(shortLink);
        }
    }
}
