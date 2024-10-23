// See https://aka.ms/new-console-template for more information
using ConsoleClient2.Entities;
using System.Text.Json;

Console.WriteLine("Hello, API!");

const string APIURL = "https://localhost:7004/WeatherForecast";

var client = new HttpClient();

var response = await client.GetAsync(APIURL);   


Console.WriteLine(response.StatusCode); 

var content = await response.Content.ReadAsStringAsync();   
Console.WriteLine(content);

var weatherForecast = JsonSerializer.Deserialize<List<Clima>>(content);

foreach (var item in weatherForecast)
{
    Console.WriteLine(item.Fecha);
    Console.WriteLine(item.Temperatura);
    Console.WriteLine(item.Descripcion);
    Console.WriteLine(item.Ubicacion);
    Console.WriteLine("------------------------------");

}
