using OpenMeteoApi.Domain.Entities;
using System.Net.Http.Json;

namespace OpenMeteoApi.Services
{
    // TODO: Move this class to an appropriate place in the solution.
    public class ForecastServices
    {
        public async Task<Forecast> GetForecast(decimal lat, decimal lon)
        { 
            using var client = new HttpClient();
            var result = await client.GetFromJsonAsync<Forecast>("https://api.open-meteo.com/v1/forecast?latitude=37.04&longitude=27.43&hourly=temperature_2m&forecast_days=1");

            return result;
        }
    }
}