using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    [Authorize]
    public class DemoAuthControllerBase : Controller
    {
        private UsuarioActual _usuarioActual;

        public UsuarioActual UsuarioActual 
        {
            get {
                if (_usuarioActual is null)
                {
                    _usuarioActual = ArmarUsuarioActual();
                }

                return _usuarioActual;
            }  
        }

        private UsuarioActual? ArmarUsuarioActual()
        {
            var claims = HttpContext.User.Claims;
            var nombreCompleto = claims.FirstOrDefault(x => x.Type == "NombreCompleto").Value;

            return new UsuarioActual
            {
                Name = HttpContext.User.Identity.Name,
                NombreCompleto = nombreCompleto
            };
        }
    }
}
