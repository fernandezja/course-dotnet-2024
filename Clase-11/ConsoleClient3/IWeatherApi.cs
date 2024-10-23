using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient3
{
    public interface IWeatherApi
    {
        [Get("/WeatherForecast")]
        Task<List<WeatherDayItem>> GetForecast();
    }
}
