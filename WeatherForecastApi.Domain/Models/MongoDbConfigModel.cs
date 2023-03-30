namespace WeatherForecastApi.Domain.Models
{
    public class MongoDbConfigModel
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string ForecastCollection { get; set; }
    }
}
