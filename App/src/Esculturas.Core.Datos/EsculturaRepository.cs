using Esculturas.Core.Datos.Interfaces;
using Esculturas.Core.Entidades;
using Esculturas.Core.Entidades.Filtros;
using Microsoft.Data.SqlClient;

namespace Esculturas.Core.Datos
{
    public class EsculturaRepository: IEsculturaRepository
    {
        public List<EsculturaCompleta> BuscarAsync(EsculturaFiltro filtro) 
        {
            var esculturas = new List<EsculturaCompleta>();

            var conn = new SqlConnection("Server=.;Database=BienalEsculturas;Integrated Security=true;Trusted_Connection=True;TrustServerCertificate=Yes;");

            var cmd = new SqlCommand();
            cmd.CommandText = "dbo.Escultura_Buscar";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@TextoABuscar", filtro.TextoABuscar);  
            cmd.Parameters.AddWithValue("@ColumnaParaOrdenar", filtro.ColumnaParaOrdenar);  
            cmd.Parameters.AddWithValue("@PageIndex", filtro.PageIndex);  
            cmd.Parameters.AddWithValue("@PageSize", filtro.PageSize);

            cmd.Connection = conn;

            conn.Open();

            var reader = cmd.ExecuteReader();

            while (reader.Read()) 
            {
                esculturas.Add(new EsculturaCompleta
                {
                    EsculturaId = reader.GetInt32(reader.GetOrdinal("EsculturaId")),
                    Titulo = reader.GetString(reader.GetOrdinal("Titulo")),
                    Descripcion = GetStringNulleable(reader, "Descripcion"),
                    Tematica = GetStringNulleable(reader, "Tematica"),
                    

                    ImagenId = GetInt32Nulleable(reader, "ImagenId"),

                    RowIndex = reader.GetInt64(reader.GetOrdinal("RowIndex")),
                    RowTotalCount = reader.GetInt64(reader.GetOrdinal("RowTotalCount"))
                    //ImagenArchivoNombre = reader.GetString(reader.GetOrdinal("ImagenArchivoNombre")),
                    //ImagenNombre = reader.GetString(reader.GetOrdinal("ImagenNombre"))
                });
            }


            return esculturas;
        }


        private int? GetInt32Nulleable(SqlDataReader reader, string columnName)
        {
            var index = reader.GetOrdinal(columnName);

            if (reader.IsDBNull(index))
            {
                return null;
            }

            return reader.GetInt32(index);
        }

        private string GetStringNulleable(SqlDataReader reader, string columnName)
        {
            var index = reader.GetOrdinal(columnName);

            if (reader.IsDBNull(index))
            {
                return null;
            }

            return reader.GetString(index);
        }
    }
}
