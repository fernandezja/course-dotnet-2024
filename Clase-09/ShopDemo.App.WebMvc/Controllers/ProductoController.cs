using Microsoft.AspNetCore.Mvc;
using ShopDemo.Core.Negocio;

namespace ShopDemo.App.WebMvc.Controllers
{
    public class ProductoController: Controller
    {
        private ProductoNegocio _productoNegocio;

        public ProductoController(ProductoNegocio productoNegocio)
        {
            _productoNegocio = productoNegocio;
        }

        public IActionResult Index()
        {
            //return Content("Producto OK");
            
            var productos = _productoNegocio.Listado();

            ViewData["Mensaje"] = "Un mensaje";
            ViewBag.Mensaje2 = "Otro mensaje";
            
            return View(productos);
        }
    }
}
