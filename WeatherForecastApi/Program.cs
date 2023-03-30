using WeatherForecastApi.Domain.Models;
using WeatherForecastApi.Services.Mongo;
using WeatherForecastApi.Services.OpenMeteoAPI;

namespace WeatherForecastApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // TODO: Free MediatR registration from dependency on Services.Index class.
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Mediator.Index).Assembly));

            builder.Services.Configure<OpenMeteoApiConfigModel>(builder.Configuration.GetSection("OpenMeteoApi"));
            builder.Services.Configure<MongoDbConfigModel>(builder.Configuration.GetSection("MongoDB"));
            
            builder.Services.AddSingleton<IOpenMeteoForecastServices, OpenMeteoForecastServices>();
            builder.Services.AddSingleton<IMongoForecastServices, MongoForecastServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}