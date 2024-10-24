using Cat.Core.ServiceInterFace;
using Cat.Models.Kitty;
using CatGame.Data;

using Microsoft.AspNetCore.Mvc;

namespace Cat.Controllers
{
    public class KittyController : Controller
    {

        private readonly CatGameContext _context;
        private readonly ICatsServices _catsServices;
        public KittyController(CatGameContext context, ICatsServices catsServices)
        {
            _context = context;
            _catsServices = catsServices;
        }
        public IActionResult Index()
        {
            var reusltingInventory = _context.CatDMs
                .OrderByDescending(y => y.CatLevel)
                .Select(x => new KittyIndexViewModel
                {
                    Id = x.Id,
                    CatName = x.CatName,
                    CatLevel = x.CatLevel,
                    CatFood = x.CatFood,


                });
            return View(reusltingInventory);
        }
    }
}
