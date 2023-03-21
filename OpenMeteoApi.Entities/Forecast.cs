namespace OpenMeteoApi.Entities
{
    public class Forecast
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Hourly Hourly { get; set; }
    }

    public class Hourly
    {
        public DateTimeOffset[] Time { get; set; }
        public decimal[] Temperature { get; set;}
    }
}