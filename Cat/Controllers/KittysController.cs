using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Web;
using Cat.Core.ServiceInterface;
using Cat.Models.Characters;
using Cat.Core.Dto;
using Cat.Data;

namespace Cat.Controllers
{
	public class KittysController : Controller
	{
		//This controls all functions for characters, including missions.

		private readonly KittyGameContext _context;
		private readonly IKittysServices _charactersServices;
		private readonly IFileServices _fileServices;

		public KittysController(KittyGameContext context, IKittysServices charactersServices, IFileServices fileServices)
		{
			_context = context;
			_charactersServices = charactersServices;
			_fileServices = fileServices;
		}
		[HttpGet]
		public IActionResult Index()
		{
			var resultingInventory = _context.Kittys
				.OrderByDescending(y => y.CharacterLevel)
				.Select(x => new KittyListIndexViewModel
				{
					ID = x.ID,
					CharacterName = x.CharacterName,
					CharacterClass = (Models.Characters.CharacterClass)x.CharacterClass,
					CharacterLevel = x.CharacterLevel,
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
				CharacterName = vm.CharacterName,
				CharacterHealth = 100,
				CharacterXP = 0,
				CharacterXPNextLevel = 100,
				CharacterLevel = 0,
				CharacterClass = (Cat.Core.Dto.CharacterClass)vm.CharacterClass,
				CharacterStatus = (Cat.Core.Dto.CharacterStatus)vm.CharacterStatus,
				PrimaryAttackName = vm.PrimaryAttackName,
				PrimaryAttackPower = vm.PrimaryAttackPower,
				SpecialAttackName = vm.SpecialAttackName,
				SpecialAttackPower = vm.SpecialAttackPower,
				CharacterCreationTime = vm.CharacterCreationTime,
				Files = vm.Files,
				Image = vm.Image.Select(x => new FileToDatabaseDto
				{
					ID = x.ImageID,
					ImageData = x.ImageData,
					ImageTitle = x.ImageTitle,
					CharacterID = x.CharacterID,
				}).ToArray()
            };
			var result = await _charactersServices.Create(dto);

			if (result == null)
			{
				return RedirectToAction("Index");
			}
            return RedirectToAction("Index", vm);
        }
		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var character = await _charactersServices.DetailsAsync(id);

			if (character == null)
			{
				return NotFound();
			}
			

			var images = await _context.FilesToDatabase
				.Where(c => c.CharacterID == id)
				.Select(y => new KittyImageViewModel
				{
				CharacterID = y.ID,
					ImageID = y.ID,
					ImageData = y.ImageData,
					ImageTitle = y.ImageTitle,
					Image = string.Format("data:image/gif;base64{0}", Convert.ToBase64String(y.ImageData))
				}).ToArrayAsync();
			var vm = new KittyDetailsViewModel();
            vm.CharacterName = vm.CharacterName;
            vm.CharacterHealth = 100;
            vm.CharacterXP = 0;
            vm.CharacterXPNextLevel = 100;
            vm.CharacterLevel = 0;
			vm.CharacterClass = (Models.Characters.CharacterClass)character.CharacterClass;
			vm.CharacterStatus = (Models.Characters.CharacterStatus)character.CharacterStatus;
            vm.PrimaryAttackName = vm.PrimaryAttackName;
            vm.PrimaryAttackPower = vm.PrimaryAttackPower;
            vm.SpecialAttackName = vm.SpecialAttackName;
            vm.SpecialAttackPower = vm.SpecialAttackPower;
            vm.CharacterCreationTime = vm.CharacterCreationTime;

			return View(vm);
		}
		[HttpGet]
		public async Task<IActionResult> Update(Guid id)
		{
			if (id == null) { return NotFound(); }

			var character = await _charactersServices.DetailsAsync(id);

			if (id == null) { return NotFound(); }

			var images = await _context.FilesToDatabase
				.Where(x => x.CharacterID == id)
				.Select(y => new KittyImageViewModel
				{
					CharacterID = y.ID,
					ImageID = y.ID,
					ImageData = y.ImageData,
					ImageTitle = y.ImageTitle,
					Image = string.Format("data:image/gif;base64{0}", Convert.ToBase64String(y.ImageData))
				}).ToArrayAsync();

            var vm = new KittyCreateViewModel();
            vm.CharacterName = vm.CharacterName;
            vm.CharacterHealth = 100;
            vm.CharacterXP = 0;
            vm.CharacterXPNextLevel = 100;
            vm.CharacterLevel = 0;
            vm.CharacterClass = (Models.Characters.CharacterClass)character.CharacterClass;
            vm.CharacterStatus = (Models.Characters.CharacterStatus)character.CharacterStatus;
            vm.PrimaryAttackName = vm.PrimaryAttackName;
            vm.PrimaryAttackPower = vm.PrimaryAttackPower;
            vm.SpecialAttackName = vm.SpecialAttackName;
            vm.SpecialAttackPower = vm.SpecialAttackPower;
            vm.CharacterCreationTime = vm.CharacterCreationTime;

			return View("Update", vm);
        }
		[HttpPost]
		public async Task<IActionResult> Update(KittyCreateViewModel vm)
		{
			var dto = new KittyDto()
			{
				ID = (Guid)vm.ID,
				CharacterName = vm.CharacterName,
				CharacterHealth = 100,
				CharacterXP = 0,
				CharacterXPNextLevel = 100,
				CharacterLevel = 0,
				CharacterClass = (Cat.Core.Dto.CharacterClass)vm.CharacterClass,
				CharacterStatus = (Cat.Core.Dto.CharacterStatus)vm.CharacterStatus,
				PrimaryAttackName = vm.PrimaryAttackName,
				PrimaryAttackPower = vm.PrimaryAttackPower,
				SpecialAttackName = vm.SpecialAttackName,
				SpecialAttackPower = vm.SpecialAttackPower,
				CharacterCreationTime = vm.CharacterCreationTime,
				Files = vm.Files,
				Image = vm.Image.Select(x => new FileToDatabaseDto
				{
					ID = x.ImageID,
					ImageData = x.ImageData,
					ImageTitle = x.ImageTitle,
					CharacterID = x.CharacterID,
				}).ToArray(),
			};
			var result = await _charactersServices.Update(dto);
			
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

			var character = await _charactersServices.DetailsAsync(id);

			if (id == null) { return NotFound(); };

			var images = await _context.FilesToDatabase
				.Where(x => x.CharacterID == id)
				.Select( y => new KittyImageViewModel
				{
					CharacterID = y.ID,
					ImageID = y.ID,
					ImageData = y.ImageData,
					ImageTitle = y.ImageTitle,
					Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
				}).ToArrayAsync();
			var vm = new KittyDeleteViewModel();

			vm.ID = character.ID;
			vm.CharacterName = character.CharacterName;
			vm.CharacterHealth = 100;
			vm.CharacterXP = 0;
			vm.CharacterXPNextLevel = 100;
			vm.CharacterLevel = 0;
			vm.CharacterClass = (Models.Characters.CharacterClass)character.CharacterClass;
			vm.CharacterStatus = (Models.Characters.CharacterStatus)character.CharacterStatus;
			vm.PrimaryAttackName = character.PrimaryAttackName;
			vm.PrimaryAttackPower = character.PrimaryAttackPower;
			vm.SpecialAttackName = character.SpecialAttackName;
			vm.SpecialAttackPower = character.SpecialAttackPower;
			vm.CharacterCreationTime = character.CharacterCreationTime;
			vm.Image.AddRange(images);
			
			return View(vm);
		}
		[HttpPost]
		public async Task<IActionResult> DeleteConfirmation(Guid id)
		{
			var characterToDelete = await _charactersServices.Delete(id);

			if (characterToDelete == null) { return RedirectToAction("Index"); }

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
