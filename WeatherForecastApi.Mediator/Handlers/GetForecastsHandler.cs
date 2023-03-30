using MediatR;
using WeatherForecastApi.Domain.Dtos;
using WeatherForecastApi.Mediator.Queries;
using WeatherForecastApi.Services.Mongo;

namespace WeatherForecastApi.Mediator.Handlers
{
    public class GetForecastsHandler : IRequestHandler<GetForecastsQuery, ForecastResponseDto>
    {
        private readonly IMongoForecastServices _mongoForecastServices;

        public GetForecastsHandler(IMongoForecastServices mongoForecastServices)
        {
            _mongoForecastServices = mongoForecastServices;
        }

        public async Task<ForecastResponseDto> Handle(GetForecastsQuery request, CancellationToken cancellationToken)
        {
            // Get forecast from MongoDb
            var forecast = await _mongoForecastServices.GetForecast(request.Latitude, request.Longitude, new DateTimeOffset());
            
            if (forecast == null) return null!;

            //var forecastDto = forecast.MapTo();
            var forecastDto = (ForecastResponseDto)forecast;
            return forecastDto;
        }
    }
}
