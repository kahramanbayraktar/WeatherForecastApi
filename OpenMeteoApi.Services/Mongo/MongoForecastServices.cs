using MongoDB.Driver;
using OpenMeteoApi.Domain.Entities;

namespace OpenMeteoApi.Services.Mongo
{
    public class MongoForecastServices
    {
        public async Task<Forecast> GetForecast(decimal lat, decimal lon, DateTimeOffset date)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://forecastadmin:vM8SfUYk9RVlV36n@cluster0.6mda7f5.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("OpenMeteo");

            var forecasts = database.GetCollection<Forecast>("Forecasts");

            var builder = Builders<Forecast>.Filter;
            var filter = builder.Eq(x => x.Latitude, lat);

            var doc = await forecasts.FindAsync(filter).Result.FirstOrDefaultAsync();
            //var doc = forecasts.Find(_ => true).FirstOrDefault();

            return doc;
        }

        public async Task<bool?> SaveForecast(Forecast forecast)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://forecastadmin:vM8SfUYk9RVlV36n@cluster0.6mda7f5.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("OpenMeteo");

            var forecasts = database.GetCollection<Forecast>("Forecasts");

            await forecasts.InsertOneAsync(forecast);

            return true;
        }
    }
}
