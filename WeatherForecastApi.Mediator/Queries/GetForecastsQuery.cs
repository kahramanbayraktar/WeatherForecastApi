using MediatR;
using WeatherForecastApi.Domain.Dtos;

namespace WeatherForecastApi.Mediator.Queries
{
    public class GetForecastsQuery : IRequest<ForecastResponseDto>
    {
        public GetForecastsQuery(decimal lat, decimal lon)
        {
            Latitude = lat;
            Longitude = lon;

        }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
