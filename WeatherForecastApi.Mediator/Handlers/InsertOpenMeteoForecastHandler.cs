using MediatR;
using WeatherForecastApi.Mediator.Commands;
using WeatherForecastApi.Services.Mongo;

namespace WeatherForecastApi.Mediator.Handlers
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
