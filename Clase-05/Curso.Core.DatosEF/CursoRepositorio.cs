using Curso.Core.Datos.Interfaces;
using Curso.Core.Entidades;
using Curso.Core.Entidades.Filtros;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata;

namespace Curso.Core.DatosEF
{
    public class CursoRepositorio : ICursoRepositorio
    {
        public AppConfig Config { get; set; }
        

        public CursoRepositorio(AppConfig config)
        {
            Config = config;

        }

        private CursoContext _dbContext;
        public CursoContext DbContext {
            get {
                return GetDbContext();
            } 
        }

        private CursoContext GetDbContext()
        {
            if (_dbContext == null)
            {
                _dbContext = new CursoContext();
                _dbContext.Config = Config;
            }
            return _dbContext;
        }


        public List<Entidades.Curso> ObtenerListado()
        {
            DbContext.Config = Config;

            return DbContext.Cursos.ToList();

        }

        public List<Entidades.Curso> Buscar(string textoABuscar)
        {
            DbContext.Config = Config;

            var query = DbContext.Cursos
                            .Where(c => c.CursoNombre.Contains(textoABuscar));

            return query.ToList();

        }

        public List<Entidades.Curso> Buscar(BuscarFiltro filtro)
        {
            DbContext.Config = Config;

            var skip = (filtro.PageIndex - 1) * filtro.PageSize;

            var query = DbContext.Cursos
                            .Skip(skip)
                            .Take(filtro.PageSize)
                            .Where(c => c.CursoNombre.Contains(filtro.TextoABuscar));

            return query.ToList();

        }

        public bool Crear(Entidades.Curso curso)
        {
            DbContext.Cursos.Add(curso);

            DbContext.SaveChanges();
            

            return true;
        }

        public Entidades.Curso BuscarPorNombreExacto(string cursoNombre)
        {
            var query = DbContext.Cursos
                            
                            .Where(c => EF.Functions.Collate(c.CursoNombre, "SQL_Latin1_General_CP1_CI_AI") == EF.Functions.Collate(cursoNombre, "SQL_Latin1_General_CP1_CI_AI"));

            return query.FirstOrDefault();
        }


        public bool Eliminar(int cursoId)
        {
            var query = DbContext.Cursos
                             .Where( c => c.CursoId == cursoId);

            var cursoParaEliminar = query.FirstOrDefault();

            if (cursoParaEliminar is not null)
            {
                DbContext.Cursos.Remove(cursoParaEliminar);

                DbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public bool Editar(Entidades.Curso curso)
        {

            var query = DbContext.Cursos
                             .Where(c => c.CursoId == curso.CursoId);

            var cursoParaEditar = query.FirstOrDefault();

            cursoParaEditar.CursoNombre = curso.CursoNombre;

            //DbContext.Attach

            DbContext.SaveChanges();

            return true;
        }
    }
}
