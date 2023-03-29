using WeatherForecastApi.Domain.Dtos;

namespace WeatherForecastApi.Services.OpenMeteoAPI
{
    public interface IOpenMeteoForecastServices
    {
        Task<OpenMeteoForecastDto> GetForecast(decimal lat, decimal lon);
    }
}