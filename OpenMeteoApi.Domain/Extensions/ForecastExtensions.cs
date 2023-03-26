using OpenMeteoApi.Domain.Dtos;
using OpenMeteoApi.Domain.Entities;

namespace OpenMeteoApi.Domain.Extensions
{
    public static class ForecastExtensions
    {
        // TODO: Not in use at the moment.
        public static ForecastResponseDto MapTo(this Forecast forecast)
        {
            return new ForecastResponseDto(forecast.Latitude, forecast.Longitude, forecast.Hourly.Time,
                forecast.Hourly.Temperature);
        }
    }
}
