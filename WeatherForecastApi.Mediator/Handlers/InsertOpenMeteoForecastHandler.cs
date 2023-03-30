using MediatR;
using WeatherForecastApi.Mediator.Commands;
using WeatherForecastApi.Services.Mongo;

namespace WeatherForecastApi.Mediator.Handlers
{
    public class InsertOpenMeteoForecastHandler : IRequestHandler<InsertForecastCommand, bool?>
    {
        private readonly IMongoForecastServices _mongoForecastServices;

        public InsertOpenMeteoForecastHandler(IMongoForecastServices mongoForecastServices)
        {
            _mongoForecastServices = mongoForecastServices;
        }

        public async Task<bool?> Handle(InsertForecastCommand request, CancellationToken cancellationToken)
        {
            return await _mongoForecastServices.SaveForecast(request.forecast);
        }
    }
}
