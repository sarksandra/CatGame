using Microsoft.AspNetCore.Mvc;

namespace Cat.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
