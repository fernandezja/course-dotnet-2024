using Esculturas.Core.Entidades.Filtros;
using Esculturas.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esculturas.Core.Negocio.Interfaces
{
    public interface IEsculturaNegocio
    {
        List<EsculturaCompleta> BuscarAsync(EsculturaFiltro filtro);
    }
}
