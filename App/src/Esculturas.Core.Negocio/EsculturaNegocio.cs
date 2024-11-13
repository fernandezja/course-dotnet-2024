using Esculturas.Core.Datos;
using Esculturas.Core.Entidades.Filtros;
using Esculturas.Core.Datos.Interfaces;
using Esculturas.Core.Entidades;
using Esculturas.Core.Negocio.Interfaces;

namespace Esculturas.Core.Negocio
{
    public class EsculturaNegocio : IEsculturaNegocio
    {
        private readonly IEsculturaRepository _esculturaRepository;

        public EsculturaNegocio(IEsculturaRepository esculturaRepository)
        {
            _esculturaRepository = esculturaRepository;
        }


        public List<EsculturaCompleta> BuscarAsync(EsculturaFiltro filtro)
        {

            //if (filtro is null)
            //{
            //    throw new ArgumentException("Filtro invalido");
            //}
            ArgumentNullException.ThrowIfNull(filtro, "Filtro");


            return _esculturaRepository.BuscarAsync(filtro);    
        }
    }
}
