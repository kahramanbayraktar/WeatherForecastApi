using Microsoft.Extensions.Options;
using WeatherForecastApi.Domain.Dtos;
using WeatherForecastApi.Domain.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace WeatherForecastApi.Services.OpenMeteoAPI
{
    // TODO: Move this class to an appropriate place in the solution.
    public class OpenMeteoForecastServices : IOpenMeteoForecastServices
    {
        private readonly IOptionsMonitor<OpenMeteoApiConfigModel> _openMeteoApiOptions;

        public OpenMeteoForecastServices(IOptionsMonitor<OpenMeteoApiConfigModel> openMeteoApiOptions)
        {
            _openMeteoApiOptions = openMeteoApiOptions;
        }

        public async Task<OpenMeteoForecastDto> GetForecast(decimal lat, decimal lon)
        {
            HttpClient httpClient = new(); // TODO: Factory?

            try
            {
                return await httpClient.GetFromJsonAsync<OpenMeteoForecastDto>($"{_openMeteoApiOptions.CurrentValue.ForecastUri}?latitude={lat}&longitude={lon}&hourly=temperature_2m&forecast_days=1");
            }
            catch (HttpRequestException) // Non-success (outside of the 200-299 status code range)
            {
                Console.WriteLine("An error occurred.");
            }
            catch (NotSupportedException) // When content type is invalid (not a valid media type such as “application/json”)
            {
                Console.WriteLine("The content type is not supported.");
            }
            catch (JsonException) // Invalid JSON
            {
                Console.WriteLine("Invalid JSON.");
            }

            return null!;
        }
    }
}