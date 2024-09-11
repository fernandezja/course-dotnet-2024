using Curso.Core.Datos.Interfaces;
using Curso.Core.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Curso.Core.DatosEF
{
    public class CursoRepositorio : ICursoRepositorio
    {
      
        public List<Curso.Core.Entidades.Curso> ObtenerListado()
        {
            using (var dbContext = new CursoContext())
            {
                return dbContext.Cursos.ToList();
            }

        }

        public List<Curso.Core.Entidades.Curso> Buscar(string textoABuscar)
        {
            using (var dbContext = new CursoContext())
            {
                var query = dbContext.Cursos
                                .Where(c => c.CursoNombre.Contains(textoABuscar));

                return query.ToList();
            }

        }
    }
}
