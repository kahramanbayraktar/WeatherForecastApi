using MediatR;
using WeatherForecastApi.Domain.Entities;

namespace WeatherForecastApi.Mediator.Commands
{
    public record InsertForecastCommand(Forecast forecast) : IRequest<bool?>;
}
