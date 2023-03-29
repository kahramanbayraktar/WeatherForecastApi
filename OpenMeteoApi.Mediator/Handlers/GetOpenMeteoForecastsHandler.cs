using MediatR;
using OpenMeteoApi.Domain.Dtos;
using OpenMeteoApi.Mediator.Queries;
using OpenMeteoApi.Services.OpenMeteoAPI;

namespace OpenMeteoApi.Mediator.Handlers
{
    public class GetOpenMeteoForecastsHandler : IRequestHandler<GetOpenMeteoForecastsQuery, OpenMeteoForecastDto>
    {
        public async Task<OpenMeteoForecastDto> Handle(GetOpenMeteoForecastsQuery request, CancellationToken cancellationToken)
        {
            // Get forecast from OpenMeteoAPI
            OpenMeteoForecastServices services = new();
            var forecast = await services.GetForecast(request.Latitude, request.Longitude);
            return forecast;
        }
    }
}
