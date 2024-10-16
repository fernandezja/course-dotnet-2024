using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult Login([FromBody] UsuarioLoginViewModel usuario)
        public async Task<IActionResult> Login(string usuario, string password)
        {
            var esValido = false;

            if (usuario == password)
            {
                esValido = true;
            }
            else
            {
                ViewBag.Mensaje = "Datos incorrectos.";
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario),
                new Claim("NombreCompleto", "Curso NET")
            };

            var claimsIdentity =
                new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties() {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10)
                //RedirectUri = "/admin/index"
            };

            //
            await HttpContext.SignInAsync(
                   CookieAuthenticationDefaults.AuthenticationScheme,
                   new System.Security.Claims.ClaimsPrincipal(claimsIdentity),
                   authProperties
                );

            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/auth/login?from=logout");
            
        }
    }
}
