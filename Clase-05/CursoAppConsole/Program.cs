// See https://aka.ms/new-console-template for more information
using Curso.Core.Datos;
using Curso.Core.Entidades;
using Curso.Core.Entidades.Filtros;
using Curso.Core.Negocio;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Cursos!");

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var configuration = builder.Build();

var titulo1 = configuration["Titulo"];
var titulo2 = configuration.GetSection("Titulo").Value;
var connectionString1 = configuration.GetSection("ConnectionStrings:CursoConnectionString").Value;

var appConfig = new AppConfig(){
    Titulo = configuration.GetSection("Titulo").Value,
    ConnectionString = configuration.GetConnectionString("CursoConnectionString")
};

var cursoNegocio = new CursoNegocio(appConfig);

var cursos = cursoNegocio.ObtenerListado();

foreach (var curso in cursos)
{
    Console.WriteLine($"Curso: {curso.CursoNombre}");
}

Console.WriteLine();
Console.WriteLine($"Paginado ----------------------------");
Console.WriteLine();

var filtro = new BuscarFiltro()
{
    TextoABuscar = "",
    PageIndex = 1,
    PageSize = 3
};

cursos = cursoNegocio.Buscar(filtro);

foreach (var curso in cursos)
{
    Console.WriteLine($"Curso: {curso.CursoNombre}");
}