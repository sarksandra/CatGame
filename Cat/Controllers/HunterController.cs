using Microsoft.AspNetCore.Mvc;

namespace Cat.Controllers
{
    public class HunterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
