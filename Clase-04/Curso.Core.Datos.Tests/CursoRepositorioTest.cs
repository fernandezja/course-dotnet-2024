namespace Curso.Core.Datos.Tests
{
    public class CursoRepositorioTest
    {
        [Fact]
        public void Obtener_Curso_Listado()
        {
            var cursoRepositorio = new CursoRepositorio();

            var cursos = cursoRepositorio.ObtenerListado();

            Assert.NotNull(cursos);
            Assert.NotEmpty(cursos);
            Assert.Equal(1, cursos.Count);

            var curso1 = cursos.First();

            Assert.Equal(".NET", curso1.CursoNombre);
            Assert.Equal("Profe B", curso1.ProfesorNombre);
        }
    }
}