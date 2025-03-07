using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Web;
using Cat.Core.ServiceInterface;
using Cat.Models.Kittys;
using Cat.Core.Dto;
using Cat.Data;

namespace Cat.Controllers
{
	public class KittysController : Controller
	{
		

		private readonly KittyGameContext _context;
		private readonly IKittysServices _kittyServices;
		private readonly IFileServices _fileServices;

		public KittysController(KittyGameContext context, IKittysServices kittyServices, IFileServices fileServices)
		{
			_context = context;
            _kittyServices = kittyServices;
			_fileServices = fileServices;
		}
		[HttpGet]
		public IActionResult Index()
		{
			var resultingInventory = _context.Kittys
				.OrderByDescending(y => y.KittyLevel)
				.Select(x => new KittyListIndexViewModel
				{
					ID = x.ID,
					KittyName = x.KittyName,
					KittyType = (Models.Kittys.KittyType)x.KittyType,
					KittyLevel = x.KittyLevel,
				});
			return View(resultingInventory);
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
			var dto = new KittyDto
			{
				KittyName = vm.KittyName,
				KittyXP = 0,
				KittyXPNextLevel = 100,
				KittyLevel = 0,
				KittyType = (Core.Dto.KittyType)vm.KittyType,
				KittyStatus = (Core.Dto.KittyStatus)vm.KittyStatus,
				FoodName = vm.FoodName,
				FoodPower = vm.FoodPower,
				SpecialFoodName = vm.SpecialFoodName,
				SpecialFood = vm.SpecialFood,
				CreationTime = vm.CreationTime,
				Files = vm.Files,
				Image = vm.Image.Select(x => new FileToDatabaseDto
				{
					ID = x.ImageID,
					ImageData = x.ImageData,
					ImageTitle = x.ImageTitle,
					KittyID = x.KittyID,
				}).ToArray()
            };
			var result = await _kittyServices.Create(dto);

			if (result == null)
			{
				return RedirectToAction("Index");
			}
            return RedirectToAction("Index", vm);
        }
		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			//if (id == null)
			//{
			//	return NotFound();
			//}

			var kitty = await _kittyServices.DetailsAsync(id);

			if (kitty == null)
			{
				return NotFound();
			}
			

			var images = await _context.FilesToDatabase
				.Where(c => c.KittyID == id)
				.Select(y => new KittyImageViewModel
				{
					KittyID = y.ID,
					ImageID = y.ID,
					ImageData = y.ImageData,
					ImageTitle = y.ImageTitle,
					Image = string.Format("data:image/gif;base64{0}", Convert.ToBase64String(y.ImageData))
				}).ToArrayAsync();

			var vm = new KittyDetailsViewModel();
			vm.ID = kitty.ID;
            vm.KittyName = kitty.KittyName;
            vm.KittyXP = 0;
            vm.KittyXPNextLevel = 100;
            vm.KittyLevel = 0;
			vm.KittyType = (Models.Kittys.KittyType)kitty.KittyType;
			vm.KittyStatus = (Models.Kittys.KittyStatus)kitty.KittyStatus;
            vm.FoodName = kitty.FoodName;
            vm.FoodPower = kitty.FoodPower;
            vm.SpecialFoodName = kitty.SpecialFoodName;
            vm.SpecialFood = kitty.SpecialFood;
            vm.CreationTime = kitty.CreationTime;
			vm.Image.AddRange(images);

			return View(vm);
		}
		[HttpGet]
		public async Task<IActionResult> Update(Guid id)
		{
			if (id == null) { return NotFound(); }

			var kitty = await _kittyServices.DetailsAsync(id);

			if (id == null) { return NotFound(); }

			var images = await _context.FilesToDatabase
				.Where(x => x.KittyID == id)
				.Select(y => new KittyImageViewModel
				{
					KittyID = y.ID,
					ImageID = y.ID,
					ImageData = y.ImageData,
					ImageTitle = y.ImageTitle,
					Image = string.Format("data:image/gif;base64{0}", Convert.ToBase64String(y.ImageData))
				}).ToArrayAsync();

            var vm = new KittyCreateViewModel();
            vm.KittyName = vm.KittyName;
            vm.KittyXP = 0;
            vm.KittyXPNextLevel = 100;
            vm.KittyLevel = 0;
            vm.KittyType = (Models.Kittys.KittyType)kitty.KittyType;
            vm.KittyStatus = (Models.Kittys.KittyStatus)kitty.KittyStatus;
            vm.FoodName = vm.FoodName;
            vm.FoodPower = vm.FoodPower;
            vm.SpecialFoodName = vm.SpecialFoodName;
            vm.SpecialFood = vm.SpecialFood;
            vm.CreationTime = vm.CreationTime;

			return View("Update", vm);
        }
		[HttpPost]
		public async Task<IActionResult> Update(KittyCreateViewModel vm)
		{
			var dto = new KittyDto()
			{
				ID = (Guid)vm.ID,
				KittyName = vm.KittyName,
				KittyXP = 0,
				KittyXPNextLevel = 100,
				KittyLevel = 0,
				KittyType = (Cat.Core.Dto.KittyType)vm.KittyType,
				KittyStatus = (Cat.Core.Dto.KittyStatus)vm.KittyStatus,
				FoodName = vm.FoodName,
				FoodPower = vm.FoodPower,
				SpecialFoodName = vm.SpecialFoodName,
				SpecialFood = vm.SpecialFood,
				CreationTime = vm.CreationTime,
				Files = vm.Files,
				Image = vm.Image.Select(x => new FileToDatabaseDto
				{
					ID = x.ImageID,
					ImageData = x.ImageData,
					ImageTitle = x.ImageTitle,
					KittyID = x.KittyID,
				}).ToArray(),
			};
			var result = await _kittyServices.Update(dto);
			
			if (result == null)
			{
				return RedirectToAction("Index"); 
			}
			return RedirectToAction("Index", vm);
		}
		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			if (id == null) { return NotFound(); }

			var kitty = await _kittyServices.DetailsAsync(id);

			if (id == null) { return NotFound(); };

			var images = await _context.FilesToDatabase
				.Where(x => x.KittyID == id)
				.Select( y => new KittyImageViewModel
				{
					KittyID = y.ID,
					ImageID = y.ID,
					ImageData = y.ImageData,
					ImageTitle = y.ImageTitle,
					Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
				}).ToArrayAsync();
			var vm = new KittyDeleteViewModel();

			vm.ID = kitty.ID;
			vm.KittyName = kitty.KittyName;
			vm.KittyXP = 0;
			vm.KittyXPNextLevel = 100;
			vm.KittyLevel = 0;
			vm.KittyType = (Models.Kittys.KittyType)kitty.KittyType;
			vm.KittyStatus = (Models.Kittys.KittyStatus)kitty.KittyStatus;
			vm.FoodName = kitty.FoodName;
			vm.FoodPower = kitty.FoodPower;
			vm.SpecialFoodName = kitty.SpecialFoodName;
			vm.SpecialFood = kitty.SpecialFood;
			vm.CreationTime = kitty.CreationTime;
			vm.Image.AddRange(images);
			
			return View(vm);
		}
		[HttpPost]
		public async Task<IActionResult> DeleteConfirmation(Guid id)
		{
			var ToDelete = await _kittyServices.Delete(id);

			if (ToDelete == null) { return RedirectToAction("Index"); }

			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> RemoveImage(KittyImageViewModel vm)
		{
			var dto = new FileToDatabaseDto()
			{
				ID = vm.ImageID
			};
			var image = await _fileServices.RemoveImageFromDatabase(dto);
			if (image == null) { return RedirectToAction("Index"); }
			return RedirectToAction("Index");
		} 
	}
}
