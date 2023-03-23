using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenMeteoApi.Mediator.Queries;

namespace OpenMeteoApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(decimal lat, decimal lon)
        {
            GetForecastsQuery query = new(lat, lon);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
