using OpenMeteoApi.Domain.Dtos;
using System.Net.Http.Json;

namespace OpenMeteoApi.Services.OpenMeteoAPI
{
    // TODO: Move this class to an appropriate place in the solution.
    public class OpenMeteoForecastServices
    {
        public async Task<OpenMeteoForecastDto> GetForecast(decimal lat, decimal lon)
        {
            using var client = new HttpClient();
            var result = await client.GetFromJsonAsync<OpenMeteoForecastDto>($"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&hourly=temperature_2m&forecast_days=1");

            return result;
        }
    }
}