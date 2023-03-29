using OpenMeteoApi.Domain.Entities;

namespace OpenMeteoApi.Domain.Dtos
{
    public class ForecastResponseDto
    {
        public ForecastResponseDto(decimal lat, decimal lon, DateTimeOffset[] times, decimal[] temps)
        {
            Latitude = lat;
            Longitude = lon;
            Values = new ForecastValue[times.Length];
            for (var i = 0; i < times.Length; i++)
            {
                Values[i] = new ForecastValue(times[i], temps[i]);
            }
        }
        public decimal Latitude { get; }
        public decimal Longitude { get; }
        public ForecastValue[] Values { get; set; }

        public static explicit operator ForecastResponseDto(Forecast forecast)
        {
            return new ForecastResponseDto(forecast.Latitude, forecast.Longitude, forecast.Values.Time,
                forecast.Values.Temperature);
        }
    }

    public class ForecastValue
    {
        public ForecastValue(DateTimeOffset time, decimal temp)
        {
            Time = time;
            Temperature = temp;
        }
        public DateTimeOffset Time { get; }
        public decimal Temperature { get; }
    }
}
