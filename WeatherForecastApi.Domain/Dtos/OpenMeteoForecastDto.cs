using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WeatherForecastApi.Domain.Dtos
{
    public class OpenMeteoForecastDto
    {
        public ObjectId Id { get; set; }

        [BsonElement("latitude")]
        public decimal Latitude { get; set; }

        [BsonElement("longitude")]
        public decimal Longitude { get; set; }

        [BsonElement("hourly")]
        public Hourly Hourly { get; set; }
    }

    [DataContract]
    public class Hourly
    {
        [BsonElement("time")]
        public DateTimeOffset[] Time { get; set; }

        [JsonPropertyName("temperature_2m")] // for HttpClient requests
        [BsonElement("temperature_2m")] // for MongoDB requests
        public decimal[] Temperature { get; set; }
    }
}
