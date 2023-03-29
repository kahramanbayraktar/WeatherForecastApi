using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenMeteoApi.Domain.Dtos;
using OpenMeteoApi.Domain.Entities;
using OpenMeteoApi.Mediator.Commands;
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
            // Query MongoDB
            // (We assume that the data in MongoDB is always up-to-date.
            // It would normally require another app to get the actual data into our database. We skip this work as it is out of this project's scope.)
            GetForecastsQuery query = new(lat, lon);
            var forecastResponseDto = await _mediator.Send(query);

            if (forecastResponseDto == null)
            {
                // Query MeteoAPI
                GetOpenMeteoForecastsQuery queryOpenMeteo = new(lat, lon);
                var openMeteoForecast = await _mediator.Send(queryOpenMeteo);

                var forecast = (Forecast)openMeteoForecast;

                // Save to MongoDB
                InsertForecastCommand command = new(forecast);
                var inserted = await _mediator.Send(command);

                forecastResponseDto = (ForecastResponseDto)forecast;
            }

            return Ok(forecastResponseDto);
        }
    }
}
