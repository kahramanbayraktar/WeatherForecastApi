using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OpenMeteoApi.Domain.Entities
{
    public class Forecast
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Hourly Hourly { get; set; }
    }

    [DataContract]
    public class Hourly
    {
        public DateTimeOffset[] Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public decimal[] Temperature { get; set; } // TODO: Rename
    }
}