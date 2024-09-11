// See https://aka.ms/new-console-template for more information
using Curso.Core.Datos;
using Curso.Core.Negocio;

Console.WriteLine("Cursos!");

var cursoNegocio = new CursoNegocio();
var cursos = cursoNegocio.ObtenerListado();
foreach (var curso in cursos)
{
    Console.WriteLine($"Curso: {curso.CursoNombre}");
}
