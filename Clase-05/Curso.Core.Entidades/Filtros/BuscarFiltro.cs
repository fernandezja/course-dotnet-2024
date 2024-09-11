using System.ComponentModel.DataAnnotations.Schema;

namespace Curso.Core.Entidades.Filtros
{

    public class BuscarFiltro
    {
        public string TextoABuscar { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
