using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccesoNoPermitido()
        {
            return View();
        }

        


        [Authorize]
        public IActionResult Privacy()
        {
            //if (UsuarioActual.EstaLogeado)
            //{

            //}

            var claims = HttpContext.User.Claims;
            var nombreCompleto = claims.FirstOrDefault(x => x.Type == "NombreCompleto").Value;
            
            var usuario = new
            {
                Name = HttpContext.User.Identity.Name,
                NombreCompleto = nombreCompleto
            };


            return View(usuario);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
