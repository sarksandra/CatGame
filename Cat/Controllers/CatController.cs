using Cat.Core.ServiceInterFace;
using CatGame.Data;
using CatGame.Models.Cat;
using Microsoft.AspNetCore.Mvc;

namespace CatGame.Controllers
{
    public class CatController : Controller
    {

        private readonly CatContext _context;
        private readonly ICatsServices _catsServices;
        public CatController(CatContext context, ICatsServices catsServices)
        {
            _context = context;
            _catsServices = catsServices;
        }
        public IActionResult Index()
        {
            var reusltingInventory = _context.CatDMs
                .OrderByDescending(y => y.CatLevel)
                .Select(x => new CatIndexViewModel
                {
                    Id = x.Id,
                    CatName = x.CatName,
                    CatType = x.CatType,
                    CatLevel = x.CatLevel,
                    CatFood = x.CatFood,


                });
            return View();
        }
    }
}
