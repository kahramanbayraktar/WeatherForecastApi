using MediatR;
using OpenMeteoApi.Domain.Dtos;
using OpenMeteoApi.Mediator.Queries;
using OpenMeteoApi.Services;

namespace OpenMeteoApi.Mediator.Handlers
{
    public class GetForecastsHandler : IRequestHandler<GetForecastsQuery, ForecastResponseDto>
    {
        public async Task<ForecastResponseDto> Handle(GetForecastsQuery request, CancellationToken cancellationToken)
        {
            ForecastServices services = new();
            var forecast = await services.GetForecast(request.Latitude, request.Longitude);
            //var forecastDto = forecast.MapTo();
            var forecastDto = (ForecastResponseDto)forecast;
            return forecastDto;
        }
    }
}
