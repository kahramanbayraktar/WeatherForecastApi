using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WeatherForecastApi.Domain.Entities;
using WeatherForecastApi.Domain.Models;

namespace WeatherForecastApi.Services.Mongo
{
    public class MongoForecastServices : IMongoForecastServices
    {
        private readonly IOptionsMonitor<MongoDbConfigModel> _mongoDbOptions;
        private readonly IMongoCollection<Forecast> _forecasts;

        public MongoForecastServices(IOptionsMonitor<MongoDbConfigModel> mongoDbOptions)
        {
            _mongoDbOptions = mongoDbOptions;

            var settings = MongoClientSettings.FromConnectionString(_mongoDbOptions.CurrentValue.ConnectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase(_mongoDbOptions.CurrentValue.Database);

            _forecasts = database.GetCollection<Forecast>(_mongoDbOptions.CurrentValue.ForecastCollection);
        }

        public async Task<Forecast> GetForecast(decimal lat, decimal lon, DateTimeOffset date)
        {
            var builder = Builders<Forecast>.Filter;
            var filter = builder.Eq(x => x.Latitude, lat);

            var doc = await _forecasts.FindAsync(filter).Result.FirstOrDefaultAsync();

            return doc;
        }

        public async Task<bool?> SaveForecast(Forecast forecast)
        {
            await _forecasts.InsertOneAsync(forecast);

            return true;
        }
    }
}
