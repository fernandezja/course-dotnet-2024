using Esculturas.Core.Entidades.Filtros;
using Esculturas.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esculturas.Core.Datos.Interfaces
{
    public interface IEsculturaRepository
    {
        List<EsculturaCompleta> BuscarAsync(EsculturaFiltro filtro);
    }
}
