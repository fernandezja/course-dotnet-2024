using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return GenerateRandomWeatherForecast();
        }


        [Route("detail/{date}")]
        [HttpGet]
        public dynamic Detail(string date)
        {

            var weatherForecasts = GenerateRandomWeatherForecast();

            var weather = weatherForecasts.Where(x => x.Date.ToString("yyyy-MM-dd") == date)
                                   .FirstOrDefault();
            if (weather is null)
            {
                return new {};
            }

            return weather;
        }

#region Metodos privados
        private static IEnumerable<WeatherForecast> GenerateRandomWeatherForecast()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
                    .ToArray();
        }
#endregion

    }
}
