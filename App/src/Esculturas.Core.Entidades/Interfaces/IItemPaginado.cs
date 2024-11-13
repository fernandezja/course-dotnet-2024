using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esculturas.Core.Entidades.Interfaces
{
    public interface IItemPaginado
    {
        long RowIndex { get; set; }
        long RowTotalCount { get; set; }
    }
}
