using Microsoft.AspNetCore.Mvc;
using Shortly.Core.Mediator.Abstractions;
namespace Shortly.Services.Shortening.Api.Controllers
{
    [ApiController]
    [Route("api/short-links")]
    public class ShortLinksController : ControllerBase
    {
        protected readonly IMediator mediator;

        public ShortLinksController(IMediator mediator)
        {
            ArgumentNullException.ThrowIfNull(mediator);

            this.mediator = mediator;
        }

        [HttpPost]
        public Task<IActionResult> Create([FromBody] object request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
