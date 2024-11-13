using Esculturas.Core.Entidades.Filtros;
using Esculturas.Core.Entidades;
using Esculturas.Core.Negocio.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace Esculturas.App.Web.Controllers
{
    public class EsculturaController : Controller
    {
        private readonly IEsculturaNegocio _esculturaNegocio;

        public EsculturaController(IEsculturaNegocio esculturaNegocio)
        {
            _esculturaNegocio = esculturaNegocio;
        }


        public IActionResult Index(int? pagina)
        {
            var filtro = new EsculturaFiltro() {
                TextoABuscar = "data",
                ColumnaParaOrdenar = "TITULO ASC",
                PageIndex = pagina ?? 1,
                PageSize = 10
            };

            var esculturas = _esculturaNegocio.BuscarAsync(filtro);

            var model = new ContenidoPaginado<EsculturaCompleta>();
            model.PageIndex = filtro.PageIndex;
            model.PageSize = filtro.PageSize;
            model.SetItems(esculturas);

            return View(model);
        }
    }
}
