using Cat.Core.Dto;
using Cat.Core.ServiceInterface;
using Cat.Data;
using Cat.Models.Houses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cat.Controllers
{
    public class FoodsController : Controller
	{
		private readonly KittyGameContext _context;
		private readonly IFoodsServices _foodsServices;
		private readonly IFileServices _fileServices;

		public FoodsController(KittyGameContext context, IFoodsServices realmsServices, IFileServices fileServices)
		{
			_context = context;
			_foodsServices = realmsServices;
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
					Foodtype = (Models.Houses.Foodtype)x.Foodtype,
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
				Foodtype = (Cat.Core.Dto.Foodtype)vm.Foodtype,
				FoodLevelRequirement = vm.FoodLevelRequirement,
				Files = vm.Files,
				Image = vm.Image.Select(x => new FileToDatabaseDto
				{
					ID = x.ImageID,
					ImageData = x.ImageData,
					ImageTitle = x.ImageTitle,
					HouseID = x.FoodID,
				}).ToArray()
			};
			var result = await _foodsServices.Create(dto);
			if (result != null) 
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index", vm);
		}
	}
}
