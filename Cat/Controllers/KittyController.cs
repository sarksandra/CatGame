using Cat.Core.Dto;
using Cat.Core.ServiceInterFace;
using Cat.Models.Kitty;
using CatGame.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cat.Controllers
{
    public class KittyController : Controller
    {

        private readonly KittyGameContext _context;
        private readonly IKittysServices _catsServices;
        private readonly IFileServices _fileServices;
        public KittyController(KittyGameContext context, IKittysServices catsServices, IFileServices fileServices)
        {
            _context = context;
            _catsServices = catsServices;
            _fileServices = fileServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var reusltingInventory = _context.Kittys
                .OrderByDescending(y => y.CatLevel)
                .Select(x => new KittyIndexViewModel
                {
                    Id = x.Id,
                    CatName = x.CatName,
                    CatLevel = x.CatLevel,



                });
            return View(reusltingInventory);
        }
        [HttpGet]
        public IActionResult Create()
        {
            KittyCreateViewModel vm = new();
            return View("Create", vm);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KittyCreateViewModel vm)
        {
            var dto = new KittyDto()
            {
                CatName = vm.CatName,
                CatFoodXP = 0,
                CatFoodXPNextLevel = 100,
                CatLevel = 0,
                CatFoodType = (Core.Dto.CatFoodType)vm.CatFoodType,
                CatType = (Core.Dto.CatType)vm.CatType,
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
            if (result == null)
            {
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id /*, Guid ref*/)
        {
            var kitty = await _catsServices.DetailsAsync(id);
            if (kitty == null)
            {
                return NotFound(); // TODO, cutom partial view with message,titan is not located
            }
            var images = await _context.FilesToDatabase
                .Where(k => k.CatID == id)
                .Select(y => new KittyImageViewModel
                {
                    CatID = y.Id,
                    ImageID = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64, {0}", Convert.ToBase64String(y.ImageData))

                }).ToArrayAsync();

            var vm = new KittyDetailsViewModel();
            vm.Id = kitty.Id;
            vm.CatName = kitty.CatName;
            vm.CatType = (Models.Kitty.CatType)kitty.CatType;
            vm.CatLevel = kitty.CatLevel;
            vm.CatFoodXPNextLevel = kitty.CatFoodXPNextLevel;
            vm.Image.AddRange(images);

            return View(vm);




        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id == null) { return NotFound(); }

            var titan = await _catsServices.DetailsAsync(id);

            if (titan == null) { return NotFound(); }

            var images = await _context.FilesToDatabase
                .Where(x => x.CatID == id)
                .Select(y => new KittyImageViewModel
                {
                    CatID = y.Id,
                    ImageID = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new KittyCreateViewModel();
            vm.Id = titan.Id;
            vm.CatName = titan.CatName;
            vm.CatFoodXP = titan.CatFoodXP;
            vm.CatFoodXPNextLevel = titan.CatFoodXPNextLevel;
            vm.CatLevel = titan.CatLevel;
            vm.CatType = (Models.Kitty.CatType)titan.CatType;
            vm.CreatedAt = titan.CreatedAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Image.AddRange(images);

            return View("Update", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(KittyCreateViewModel vm)
        {
            var dto = new KittyDto()
            {
                Id = (Guid)vm.Id,
                CatName = vm.CatName,              
                CatFoodXP = 0,
                CatFoodXPNextLevel = 100,
                CatLevel= 0,
                CatFoodType = (Core.Dto.CatFoodType)vm.CatFoodType,
                CatType = (Core.Dto.CatType)vm.CatType,               
                CreatedAt = vm.CreatedAt,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image
                .Select(x => new FileToDatabaseDto
                {
                    Id = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CatID = x.CatID,
                }).ToArray()
            };
            var result = await _catsServices.Update(dto);

            if (result == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) { return NotFound(); }
            var kitty = await _catsServices.DetailsAsync(id);
            if (kitty == null) { return NotFound(); }

            var images = await _context.FilesToDatabase
                .Where(x => x.CatID == id)
                .Select(y => new KittyImageViewModel
                {
                    CatID = y.Id,
                    ImageID = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))

                }).ToArrayAsync();
            var vm = new KittyDeleteViewModel();

            vm.Id = kitty.Id;
            vm.CatName = kitty.CatName;
            vm.CatType = (Models.Kitty.CatType)kitty.CatType;
            vm.CatLevel = kitty.CatLevel;
            vm.CatFoodType = (Models.Kitty.CatFoodType)kitty.CatFoodType;
            vm.CatFoodXPNextLevel = kitty.CatFoodXPNextLevel;
            vm.CreatedAt = kitty.CreatedAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Image.AddRange(images);

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var kittyDelete = await _catsServices.Delete(id);
            if (kittyDelete != null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveImage(KittyImageViewModel vm)
        {
            var dto = new FileToDatabaseDto()
            {
                Id = vm.ImageID
            };
            var image = await _fileServices.RemoveImageFromDatabase(dto);
            if (image == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index");
        }
    }
}
