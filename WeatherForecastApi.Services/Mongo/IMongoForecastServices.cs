using WeatherForecastApi.Domain.Entities;

namespace WeatherForecastApi.Services.Mongo
{
    public interface IMongoForecastServices
    {
        Task<Forecast> GetForecast(decimal lat, decimal lon, DateTimeOffset date);
        Task<bool?> SaveForecast(Forecast forecast);
    }
}