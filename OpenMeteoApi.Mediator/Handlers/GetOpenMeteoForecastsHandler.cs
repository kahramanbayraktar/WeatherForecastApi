using MediatR;
using OpenMeteoApi.Domain.Dtos;
using OpenMeteoApi.Mediator.Queries;
using OpenMeteoApi.Services.OpenMeteoAPI;

namespace OpenMeteoApi.Mediator.Handlers
{
    public class GetOpenMeteoForecastsHandler : IRequestHandler<GetOpenMeteoForecastsQuery, OpenMeteoForecastDto>
    {
        private readonly IOpenMeteoForecastServices _openMeteoForecastServices;

        public GetOpenMeteoForecastsHandler(IOpenMeteoForecastServices openMeteoForecastServices)
        {
            _openMeteoForecastServices = openMeteoForecastServices;
        }

        public async Task<OpenMeteoForecastDto> Handle(GetOpenMeteoForecastsQuery request, CancellationToken cancellationToken)
        {
            // Get forecast from OpenMeteoAPI
            var forecast = await _openMeteoForecastServices.GetForecast(request.Latitude, request.Longitude);
            return forecast;
        }
    }
}
