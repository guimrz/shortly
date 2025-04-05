using Microsoft.AspNetCore.Mvc;
using Shortly.Core.Mediator.Abstractions;
using Shortly.Services.Shortlinks.Api.Contracts.Requests;
using Shortly.Services.Shortlinks.Api.Contracts.Responses;
using Shortly.Services.Shortlinks.Application.Commands.CreateShortLink;
using Shortly.Services.Shortlinks.Application.Queries.GetShortlink;
using Shortly.Services.Shortlinks.Application.Queries.GetShortLinkByShortCode;

namespace Shortly.Services.Shortlinks.Api.Controllers
{
    [ApiController]
    [Route("api/shortlinks")]
    public class ShortLinksController : ControllerBase
    {
        protected readonly IMediator mediator;

        public ShortLinksController(IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator);

            this.mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType<ShortlinkResponse>(201)]
        public async Task<IActionResult> Create([FromBody] CreateShortlinkRequest request, CancellationToken cancellationToken = default)
        {
            ShortlinkResponse response = await mediator.HandleAsync(new CreateShortLinkCommand(request), cancellationToken);

            return CreatedAtAction(nameof(Get), new { shortlinkId = response.Id },  response);
        }

        [HttpGet("{shortlinkId:guid}")]
        public async Task<IActionResult> Get(Guid shortlinkId, CancellationToken cancellationToken = default)
        {
            ShortlinkResponse? response = await mediator.HandleAsync(new GetShortlinkQuery(shortlinkId), cancellationToken);

            return response is null ? NotFound() : Ok(response);
        }

        [HttpGet("{shortCode}/redirect")]
        public async Task<IActionResult> LinkRedirect(string shortCode, CancellationToken cancellationToken = default)
        {
            ShortlinkResponse? response = await mediator.HandleAsync(new GetShortlinkByCodeQuery(shortCode), cancellationToken);

            return response is null ? NotFound() : Redirect(response.OriginalUrl);
        }
    }
}
