using Microsoft.AspNetCore.Mvc;

namespace CatGame.Controllers
{
    public class CatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
