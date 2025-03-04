using Cat.Core.Domain;
using Cat.Core.Dto;
using Cat.Core.Dto.AccountsDtos;
using Cat.Data;
using Cat.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cat.Controllers
{
    public class PlayerProfilesController : Controller
    {
        private readonly KittyGameContext _context;
        public PlayerProfilesController(KittyGameContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_context.PlayerProfiles.OrderByDescending(x => x.ScreenName));
        }
        [HttpGet]
        public async Task<IActionResult> NewProfile()
        {
            return View();
        }

        [HttpPost]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> NewProfile(PlayerProfileDto dto)
        {
            string userid = (string)TempData["NewUserID"];
            if (dto.ApplicationUserID == null)
            {
                return RedirectToAction("Index");
            }

            var newprofile = new PlayerProfile()
            {
                ID = dto.Id,
                ApplicationUserID = dto.ApplicationUserID,
                MyCharacters = new List<CharacterOwnership>(),
                ScreenName = "",
                Gold = 25,
                Momentos = 0,
                Victories = 0,
                CurrentStatus = ProfileStatus.Active,
                ProfileType = false
            };
            var result = await _context.PlayerProfiles.AddAsync(newprofile);
            if (result != null)
            {
                return View(Index());
            }
            return null;
        }
        [HttpGet]
        public async Task<IActionResult> NewPlayerProfile()
        {
            return View();
        }
    }
}
