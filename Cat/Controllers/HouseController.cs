using Cat.Core.Dto;
using Cat.Core.ServiceInterface;
using Cat.Data;
using Cat.Models.Houses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cat.Controllers
{
    public class HouseController : Controller
	{
		private readonly KittyGameContext _context;
		private readonly IHousesServices _realmsServices;
		private readonly IFileServices _fileServices;

		public HouseController(KittyGameContext context, IHousesServices realmsServices, IFileServices fileServices)
		{
			_context = context;
			_realmsServices = realmsServices;
			_fileServices = fileServices;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var resultingInventory = _context.Houses
				.OrderByDescending(y => y.CreatedAt)
				.Select(x => new HouseListIndexViewModel
				{
					ID = x.ID,
					HouseName = x.HouseName,
					HouseEffect = (Models.Houses.HouseEffect)x.HouseEffect,
					HouseLevelRequirement = x.HouseLevelRequirement,
				});
			return View(resultingInventory);
		}
		[HttpGet]
		public IActionResult Create()
		{
			HouseCreateViewModel vm = new();
			return View("Create", vm);
		}
		[HttpPost]
		public async Task<IActionResult> Create(HouseCreateViewModel vm)
		{
			var dto = new HouseDto
			{
				HouseName = vm.HouseName,
				HouseEffect = (Cat.Core.Dto.HouseEffect)vm.HouseEffect,
				HouseLevelRequirement = vm.HouseLevelRequirement,
				Files = vm.Files,
				Image = vm.Image.Select(x => new FileToDatabaseDto
				{
					ID = x.ImageID,
					ImageData = x.ImageData,
					ImageTitle = x.ImageTitle,
					HouseID = x.HouseID,
				}).ToArray()
			};
			var result = await _realmsServices.Create(dto);
			if (result != null) 
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index", vm);
		}
	}
}
