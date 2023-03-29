using WeatherForecastApi.Domain.Dtos;
using WeatherForecastApi.Domain.Entities;

namespace WeatherForecastApi.Domain.Factories
{
    // TODO: This class is not in use at the moment.
    public class ForecastResponseDtoFactory
    {
        public ForecastResponseDto Create(Forecast forecast)
        {
            var forecastResponseDto = new ForecastResponseDto(
                forecast.Latitude, forecast.Longitude,
                forecast.Values.Time,
                forecast.Values.Temperature);

            return forecastResponseDto;
        }
    }
}
