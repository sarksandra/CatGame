using Cat.Core.Dto;
using Cat.Core.ServiceInterFace;
using Cat.Models.Kitty;
using CatGame.Data;

using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Cat.Controllers
{
    public class KittyController : Controller
    {

        private readonly CatGameContext _context;
        private readonly IKittysServices _catsServices;
        public KittyController(CatGameContext context, IKittysServices catsServices)
        {
            _context = context;
            _catsServices = catsServices;
        }
        public IActionResult Index()
        {
            var reusltingInventory = _context.Kittys
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
        [HttpPost] 
        public IActionResult Create() 
        {
            KittyCreateViewModel vm = new();
            return View("Create", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(KittyCreateViewModel vm)
        {
            var dto = new CatDto()
            {
                CatName = vm.CatName,
                CatFoodXP = 0,
                CatFoodXPNextLevel = 100,
                CatLevel = 0,
                CatFoodType = (Core.Dto.CatFoodType)vm.CatFoodType,
                CatType = (Core.Dto.CatType)vm.CatType,
                CatFood = vm.CatFood,
                CreatedAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image
                .Select(x => new FileToDatabaseDto
                {
                    Id = x.ImageID,
                    ImageTitle = x.ImageTitle,
                    ImageData = x.ImageData, 
                    CatID = x.CatID,

                }).ToArray()

            };
            var result = await _catsServices.Create(dto);
            if(result != null)
            {
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
    }
}
