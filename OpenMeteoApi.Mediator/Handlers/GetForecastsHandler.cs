using MediatR;
using OpenMeteoApi.Domain.Dtos;
using OpenMeteoApi.Mediator.Queries;
using OpenMeteoApi.Services.Mongo;

namespace OpenMeteoApi.Mediator.Handlers
{
    public class GetForecastsHandler : IRequestHandler<GetForecastsQuery, ForecastResponseDto>
    {
        public async Task<ForecastResponseDto> Handle(GetForecastsQuery request, CancellationToken cancellationToken)
        {
            // Get forecast from MongoDb
            MongoForecastServices services = new();
            var forecast = await services.GetForecast(request.Latitude, request.Longitude, new DateTimeOffset());
            
            if (forecast == null) return null!;

            //var forecastDto = forecast.MapTo();
            var forecastDto = (ForecastResponseDto)forecast;
            return forecastDto;
        }
    }
}
