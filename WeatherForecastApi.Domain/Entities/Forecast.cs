using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WeatherForecastApi.Domain.Dtos;
using System.Runtime.Serialization;

namespace WeatherForecastApi.Domain.Entities
{
    public class Forecast
    {
        public ObjectId Id { get; set; }

        [BsonRepresentation(BsonType.Decimal128)] // So, the field in MongoDB becomes a decimal but not a string so the Find method can find it.
        [BsonElement("latitude")]
        public decimal Latitude { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        [BsonElement("longitude")]
        public decimal Longitude { get; set; }

        [BsonElement("values")]
        public ForecastValues Values { get; set; }

        public static explicit operator Forecast(OpenMeteoForecastDto openMeteoForecastDto)
        {
            return new Forecast {
            Latitude = openMeteoForecastDto.Latitude,
                Longitude = openMeteoForecastDto.Longitude,
                Values = new ForecastValues
                {
                    Time = openMeteoForecastDto.Hourly.Time,
                    Temperature = openMeteoForecastDto.Hourly.Temperature
                }
            };
        }
    }

    [DataContract]
    public class ForecastValues
    {
        [BsonRepresentation(BsonType.DateTime)] // So, the field in MongoDB becomes a DateTimeOffset but not an array of Ticks and Offset.
        [BsonElement("time")]
        public DateTimeOffset[] Time { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        [BsonElement("temperature")]
        public decimal[] Temperature { get; set; }
    }
}