using CatGame.Data;
using Microsoft.AspNetCore.Mvc;

namespace Cat.Controllers
{
    public class PlayerProfilesController : Controller
    {
        private readonly KittyGameContext _kittyContext;
        public PlayerProfilesController(KittyGameContext kittyContext)
        {
            _kittyContext = kittyContext;
        }

        public async Task<IActionResult> Index()
        {
            return View();
            
        }
    }
}
