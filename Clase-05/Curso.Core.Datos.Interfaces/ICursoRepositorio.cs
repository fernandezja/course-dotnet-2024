using Curso.Core.Entidades.Filtros;

namespace Curso.Core.Datos.Interfaces
{
    public interface ICursoRepositorio
    {
        List<Entidades.Curso> ObtenerListado();
        List<Entidades.Curso> Buscar(string textoABuscar);
        List<Entidades.Curso> Buscar(BuscarFiltro filtro);
       
        Entidades.Curso BuscarPorNombreExacto(string cursoNombre);

        bool Crear(Entidades.Curso curso);
        bool Eliminar(int cursoId);
        bool Editar(Entidades.Curso curso);
    } 
}