using Microsoft.AspNetCore.Mvc;
using WeatherForecast;

namespace WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherDayForecast> Get()
        {
            // There is an bonus bug somewhere in this functionality.
            return new WeatherForecastBuilder()
                .GenerateXDaysOfForecast(5)
                .ForCity(City.Copenhagen)
                .WithAverageCloudCoverPercetage(new Percentage(90))
                .WithAverageTemperature(new Temperature(3))
                .WithAverageWindSpeed(new Speed(6))
                .WithAverageRain(5)
                .Build().Weathers;
        }
    }
}