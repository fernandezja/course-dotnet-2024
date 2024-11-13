using Esculturas.Core.Entidades.Interfaces;

namespace Esculturas.Core.Entidades
{
    public class EsculturaCompleta: IItemPaginado
    {
        public int EsculturaId { get; set; }
        public string Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string? Tematica { get; set; }

        public int? ImagenId { get; set; }
        public string? ImagenArchivoNombre { get; set; }



        #region IItemPaginado

        public long RowIndex { get; set; }
        public long RowTotalCount { get; set; }

        #endregion


        /*
         * E.EsculturaId,
	E.Titulo,
	E.Descripcion,
	E.Tematica,

	--Escultor
	ETOR.EscultorId,
	ETOR.Nombre,
	ETOR.Apellido,
	ETOR.Nacionalidad,

	--Imagen
	IMG.ImagenId,
	IMG.ArchivoNombre,
	IMG.Nombre
         */
    }
}
