using Curso.Core.Datos.Interfaces;
using Curso.Core.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Curso.Core.Datos
{
    public class CursoRepositorio : ICursoRepositorio
    {
        private const string QUERY_SELECT = "\r\nSELECT \r\n\tC.CursoId,\r\n\tCursoNombre = C.Nombre,\r\n\tP.ProfesorId,\r\n\tProfesorNombre = P.Nombre\r\nFROM dbo.Curso C\r\n\tINNER JOIN dbo.Profesor P\r\n\t\tON C.ProfesorId = P.ProfesorId";

        public List<Entidades.Curso> Buscar(string textoABuscar)
        {
            throw new NotImplementedException();
        }

        public List<Curso.Core.Entidades.Curso> ObtenerListado()
        {
            var cursos = new List<Curso.Core.Entidades.Curso>();

            //1 Conexion
            //var sqlConnectionBuilder = new SqlConnectionStringBuilder();
            //sqlConnectionBuilder.DataSource = ".";
            //sqlConnectionBuilder.InitialCatalog = "Curso";

            var conn = new Microsoft.Data.SqlClient.SqlConnection("Persist Security Info=True;Initial Catalog=CursoDemo;Data Source=.; Application Name=Curso; Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
            //TODO: using...

            //2 Comando
            var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = QUERY_SELECT;
            cmd.CommandType = CommandType.Text;

            conn.Open();

            //3 DataReader
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var curso = new Curso.Core.Entidades.Curso();

                curso.CursoId = reader.GetInt32(0);

                //curso.CursoNombre = reader.GetString(1);
                curso.CursoNombre = reader.GetString(reader.GetOrdinal("CursoNombre"));

                //curso.ProfesorId = reader.GetInt32(2);
                //curso.ProfesorNombre = reader.GetString(3);

                cursos.Add(curso);
            }

            conn.Close();

            return cursos;
        }
    }
}
