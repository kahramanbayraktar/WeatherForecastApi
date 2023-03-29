using OpenMeteoApi.Domain.Dtos;

namespace OpenMeteoApi.Services.OpenMeteoAPI
{
    public interface IOpenMeteoForecastServices
    {
        Task<OpenMeteoForecastDto> GetForecast(decimal lat, decimal lon);
    }
}