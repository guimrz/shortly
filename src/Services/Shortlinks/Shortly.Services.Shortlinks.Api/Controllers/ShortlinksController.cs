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
    public class ShortlinksController : ControllerBase
    {
        protected readonly IMediator mediator;

        public ShortlinksController(IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator);

            this.mediator = mediator;
        }

        /// <summary>
        /// Creates a new shortlink.
        /// </summary>
        /// <param name="request">The request data.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The shortlink that was created.</returns>
        [HttpPost]
        [ProducesResponseType<ShortlinkResponse>(201)]
        public async Task<IActionResult> Create([FromBody] CreateShortlinkRequest request, CancellationToken cancellationToken = default)
        {
            ShortlinkResponse response = await mediator.HandleAsync(new CreateShortLinkCommand(request), cancellationToken);

            return CreatedAtAction(nameof(Get), new { shortlinkId = response.Id }, response);
        }

        /// <summary>
        /// Gets the specified shortlink information.
        /// </summary>
        /// <param name="shortlinkId">The shortlink identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The details of the specified shortlink.</returns>
        [HttpGet("{shortlinkId:guid}")]
        [ProducesResponseType<ShortlinkResponse>(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(Guid shortlinkId, CancellationToken cancellationToken = default)
        {
            ShortlinkResponse? response = await mediator.HandleAsync(new GetShortlinkQuery(shortlinkId), cancellationToken);

            return response is null ? NotFound() : Ok(response);
        }

        [HttpGet("{shortCode}/redirect")]
        [ProducesResponseType<ShortlinkResponse>(302)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> LinkRedirect(string shortCode, CancellationToken cancellationToken = default)
        {
            ShortlinkResponse? response = await mediator.HandleAsync(new GetShortlinkByCodeQuery(shortCode), cancellationToken);

            return response is null ? NotFound() : Redirect(response.OriginalUrl);
        }
    }
}
