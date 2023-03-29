using MediatR;
using OpenMeteoApi.Domain.Dtos;

namespace OpenMeteoApi.Mediator.Queries
{
    public class GetOpenMeteoForecastsQuery : IRequest<OpenMeteoForecastDto>
    {
        public GetOpenMeteoForecastsQuery(decimal lat, decimal lon)
        {
            Latitude = lat;
            Longitude = lon;

        }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
