// See https://aka.ms/new-console-template for more information
using ConsoleClient3;
using Refit;

Console.WriteLine("Hello, API (via Refit)!");

var weatherApi = RestService.For<IWeatherApi>("https://localhost:7004");
var weather = await weatherApi.GetForecast();

foreach (var item in weather)
{
    Console.WriteLine($"{item.Date} {item.TemperatureC}C {item.Summary} {item.Location}");
}