using Microsoft.AspNetCore.Mvc;

namespace WebAppMVC01.Controllers
{
    
    public class JediController : Controller
    {
        [Route("jedis")]
        [Route("jedis.html")]
        public IActionResult Index()
        {
            return Content("Jedi Controller");
        }


        [Route("jedi-{id:int}")]
        [Route("jedi-{id:int}.html")]
        public IActionResult Details(int id)
        {
            return Content($"Jedi Details {id}");
        }

        [Route("jedi-{name}-{id:int}")]
        [Route("jedi-{name}-{id:int}.html")]
        public IActionResult DetailsComplete(int id, string name)
        {
            return Content($"Jedi Details {name} ({id})");
        }
    }
}
