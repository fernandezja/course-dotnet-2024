using Microsoft.AspNetCore.Mvc;
using ShopDemo.Core.Negocio;

namespace ShopDemo.App.WebMvc.Controllers
{
    public class CarritoController: Controller
    {
        private Carrito _carrito;

        public CarritoController(Carrito carrito)
        {
            _carrito = carrito;
        }

        public IActionResult Index()
        {
            return View(_carrito);
        }


        [HttpPost("carrito/agregar")]
        public IActionResult Agregar(int productoId)
        {
            _carrito.Agregar(productoId);


            return View("CarritoDetalle", _carrito);
        }
    }
}
