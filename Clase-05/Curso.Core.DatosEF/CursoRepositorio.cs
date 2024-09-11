using Curso.Core.Datos.Interfaces;
using Curso.Core.Entidades;
using Curso.Core.Entidades.Filtros;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Curso.Core.DatosEF
{
    public class CursoRepositorio : ICursoRepositorio
    {
        public AppConfig Config { get; set; }

        public CursoRepositorio(AppConfig config)
        {
            Config = config;
        }

        public List<Entidades.Curso> ObtenerListado()
        {
            using (var dbContext = new CursoContext())
            {
                dbContext.Config = Config;

                return dbContext.Cursos.ToList();
            }

        }

        public List<Entidades.Curso> Buscar(string textoABuscar)
        {
            using (var dbContext = new CursoContext())
            {
                dbContext.Config = Config;

                var query = dbContext.Cursos
                                .Where(c => c.CursoNombre.Contains(textoABuscar));

                return query.ToList();
            }

        }

        public List<Entidades.Curso> Buscar(BuscarFiltro filtro)
        {
            using (var dbContext = new CursoContext())
            {
                dbContext.Config = Config;

                var skip = (filtro.PageIndex - 1) * filtro.PageSize;

                var query = dbContext.Cursos
                                .Skip(skip) 
                                .Take(filtro.PageSize)
                                .Where(c => c.CursoNombre.Contains(filtro.TextoABuscar));

                return query.ToList();
            }

        }
    }
}
