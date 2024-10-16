using Microsoft.AspNetCore.Mvc;

namespace WebApplication10.Controllers
{
    public class AdminController : DemoAuthControllerBase
    {
        public IActionResult Index()
        {
            return View(UsuarioActual);
        }
    }
}
