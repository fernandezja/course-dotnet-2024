using Curso.Core.Datos;
using Curso.Core.Datos.Interfaces;

namespace Curso.Core.Negocio
{
    public class CursoNegocio
    {
        private ICursoRepositorio _cursoRepositorio;

        public CursoNegocio()
        {
            //_cursoRepositorio = new Curso.Core.Datos.CursoRepositorio();
            _cursoRepositorio = new Curso.Core.DatosEF.CursoRepositorio();
        }

        public List<Curso.Core.Entidades.Curso> ObtenerListado() { 
            return _cursoRepositorio.ObtenerListado();
        }

        public List<Curso.Core.Entidades.Curso> Buscar(string textoABuscar)
        {
            return _cursoRepositorio.Buscar(textoABuscar);
        }
    }
}
