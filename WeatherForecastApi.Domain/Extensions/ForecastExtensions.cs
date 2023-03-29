using WeatherForecastApi.Domain.Dtos;
using WeatherForecastApi.Domain.Entities;

namespace WeatherForecastApi.Domain.Extensions
{
    public static class ForecastExtensions
    {
        // TODO: Not in use at the moment.
        public static ForecastResponseDto MapTo(this Forecast forecast)
        {
            return new ForecastResponseDto(forecast.Latitude, forecast.Longitude, forecast.Values.Time,
                forecast.Values.Temperature);
        }
    }
}
