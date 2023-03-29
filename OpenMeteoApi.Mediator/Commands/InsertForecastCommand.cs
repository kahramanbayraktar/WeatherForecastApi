using MediatR;
using OpenMeteoApi.Domain.Entities;

namespace OpenMeteoApi.Mediator.Commands
{
    public record InsertForecastCommand(Forecast forecast) : IRequest<bool?>;
}
