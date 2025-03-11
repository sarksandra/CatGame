using Cat.ApplicationServices.Services;
using Cat.Core.Dto;
using Cat.Core.ServiceInterface;
using Cat.Data;
using Cat.Models.Foods;
using Cat.Models.Kittys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cat.Controllers
{
    public class FoodsController : Controller
	{
		private readonly KittyGameContext _context;
		private readonly IFoodsServices _foodsServices;
		private readonly IFileServices _fileServices;

		public FoodsController(KittyGameContext context, IFoodsServices foodsServices, IFileServices fileServices)
		{
			_context = context;
			_foodsServices = foodsServices;
			_fileServices = fileServices;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var resultingInventory = _context.Foods
				.OrderByDescending(y => y.CreatedAt)
				.Select(x => new FoodsListIndexViewModel
				{
					ID = x.ID,
					FoodName = x.FoodName,
					Foodtype = (Models.Foods.Foodtype)x.Foodtype,
					FoodLevelRequirement = x.FoodLevelRequirement,
				});
			return View(resultingInventory);
		}
		[HttpGet]
		public IActionResult Create()
		{
			FoodsCreateViewModel vm = new();
			return View("Create", vm);
		}
		[HttpPost]
		public async Task<IActionResult> Create(FoodsCreateViewModel vm)
		{
			var dto = new FoodDto
			{
				FoodName = vm.FoodName,
				Foodtype = (Core.Dto.Foodtype)vm.Foodtype,
				FoodLevelRequirement = vm.FoodLevelRequirement,
				Files = vm.Files,
				Image = vm.Image.Select(x => new FileToDatabaseDto
				{
					ID = x.ImageID,
					ImageData = x.ImageData,
					ImageTitle = x.ImageTitle,
					FoodID = x.FoodID,
				}).ToArray()
			};
			var result = await _foodsServices.Create(dto);
			if (result != null) 
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index", vm);
		}
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) { return NotFound(); }

            var kitty = await _foodsServices.DetailsAsync(id);

            if (id == null) { return NotFound(); };

            var images = await _context.FilesToDatabase
                .Where(x => x.KittyID == id)
                .Select(y => new FoodsImageViewModel
                {
                    FoodID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new FoodsDeleteViewModel();

            vm.ID = kitty.ID;
            vm.FoodName = kitty.FoodName;
            vm.FoodLevelRequirement = 100;
            vm.Foodtype = (Models.Foods.Foodtype)kitty.Foodtype;
            vm.Image.AddRange(images);

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var ToDelete = await _foodsServices.Delete(id);

            if (ToDelete == null) { return RedirectToAction("Index"); }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveImage(FoodsImageViewModel vm)
        {
            var dto = new FileToDatabaseDto()
            {
                ID = vm.ImageID
            };
            var image = await _fileServices.RemoveImageFromDatabase(dto);
            if (image == null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index");
        }
		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
            if (id == null) { return NotFound(); }

            var kitty = await _foodsServices.DetailsAsync(id);

            if (id == null) { return NotFound(); };

            var images = await _context.FilesToDatabase
                .Where(x => x.KittyID == id)
                .Select(y => new FoodsImageViewModel
                {
                    FoodID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new FoodsDetailsViewModel();

            vm.ID = kitty.ID;
            vm.FoodName = kitty.FoodName;
            vm.FoodLevelRequirement = 100;
            vm.Foodtype = (Models.Foods.Foodtype)kitty.Foodtype;
            vm.Image.AddRange(images);

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id == null) { return NotFound(); }

            var kitty = await _foodsServices.DetailsAsync(id);

            if (id == null) { return NotFound(); }

            var images = await _context.FilesToDatabase
                .Where(x => x.KittyID == id)
                .Select(y => new FoodsImageViewModel
                {
                    FoodID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new FoodsCreateViewModel();
            vm.FoodName = vm.FoodName;
            vm.FoodLevelRequirement = 100;
            vm.Foodtype = (Models.Foods.Foodtype)kitty.Foodtype;

            return View("Update", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(FoodsCreateViewModel vm)
        {
            var dto = new FoodDto()
            {
                ID = (Guid)vm.ID,
                FoodLevelRequirement = 100,
                Foodtype = (Core.Dto.Foodtype)vm.Foodtype,
                FoodName = vm.FoodName,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    KittyID = x.FoodID,
                }).ToArray(),
            };
            var result = await _foodsServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }
    }
    

}
