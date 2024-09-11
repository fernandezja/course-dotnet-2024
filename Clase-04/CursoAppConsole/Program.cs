// See https://aka.ms/new-console-template for more information
using Curso.Core.Datos;

Console.WriteLine("Cursos!");

var cursoRepositorio = new CursoRepositorio();
var cursos = cursoRepositorio.ObtenerListado();
foreach (var curso in cursos)
{
    Console.WriteLine($"Curso: {curso.CursoNombre}, Profesor: {curso.ProfesorNombre}");
}
