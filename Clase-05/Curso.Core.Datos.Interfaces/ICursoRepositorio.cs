
namespace Curso.Core.Datos.Interfaces
{
    public interface ICursoRepositorio
    {
        List<Entidades.Curso> ObtenerListado();
        List<Entidades.Curso> Buscar(string textoABuscar);
    }
}