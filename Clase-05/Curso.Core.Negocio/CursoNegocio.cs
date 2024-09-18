using Curso.Core.Datos;
using Curso.Core.Datos.Interfaces;
using Curso.Core.Entidades;
using Curso.Core.Entidades.Filtros;

namespace Curso.Core.Negocio
{
    public class CursoNegocio
    {
        public AppConfig Config { get; set; }
        private ICursoRepositorio _cursoRepositorio;

        public CursoNegocio(AppConfig appConfig)
        {
            Config = appConfig;

            //_cursoRepositorio = new Curso.Core.Datos.CursoRepositorio();
            _cursoRepositorio = new Curso.Core.DatosEF.CursoRepositorio(Config);
        }

        public List<Entidades.Curso> ObtenerListado() { 
            return _cursoRepositorio.ObtenerListado();
        }

        public List<Entidades.Curso> Buscar(string textoABuscar)
        {
            return _cursoRepositorio.Buscar(textoABuscar);
        }
        public List<Entidades.Curso> Buscar(BuscarFiltro filtro)
        {
            if (filtro is null)
            {
                throw new ArgumentException("El filtro es invalido");
            }

            return _cursoRepositorio.Buscar(filtro);
        }

        public bool Crear(Entidades.Curso curso)
        {
            var cursoExistente = BuscarPorNombreExacto(curso.CursoNombre);
           
            if (cursoExistente is not null)
            {
                throw new ArgumentException("Ya existe un curso con el mismo nombre");
            }

            return _cursoRepositorio.Crear(curso);
        }

        private Entidades.Curso BuscarPorNombreExacto(string cursoNombre)
        {
            return _cursoRepositorio.BuscarPorNombreExacto(cursoNombre);
        }

        public bool Eliminar(int cursoId)
        {
            return _cursoRepositorio.Eliminar(cursoId);
        }

        public bool Editar(Entidades.Curso curso)
        {
            return _cursoRepositorio.Editar(curso);
        }
    }
}
