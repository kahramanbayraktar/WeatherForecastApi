using MediatR;
using OpenMeteoApi.Mediator.Commands;
using OpenMeteoApi.Services.Mongo;

namespace OpenMeteoApi.Mediator.Handlers
{
    public class InsertOpenMeteoForecastHandler : IRequestHandler<InsertForecastCommand, bool?>
    {
        public async Task<bool?> Handle(InsertForecastCommand request, CancellationToken cancellationToken)
        {
            MongoForecastServices services = new();
            return await services.SaveForecast(request.forecast);
        }
    }
}
