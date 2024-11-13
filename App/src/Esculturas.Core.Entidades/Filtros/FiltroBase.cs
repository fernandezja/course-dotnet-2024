namespace Esculturas.Core.Entidades.Filtros
{
    public class FiltroBase
    {
        public string ColumnaParaOrdenar { get; set; }
        public int PageIndex { get; set; }
        public Int64 PageSize { get; set; }
        public string TextoABuscar { get; set; }
    }
}