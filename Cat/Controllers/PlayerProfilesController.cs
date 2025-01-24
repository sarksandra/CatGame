using Cat.Core.Domain;
using Cat.Core.Dto;
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
            if (dto.ApplicationUserID == null)
            {
                List<string> errordatas =
                        [
                        "Area", "Accounts",
                        "Issue", "Failure",
                        "StatusMessage", "No user id found"
                        ];
                ViewBag.ErrorDatas = errordatas;
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            var newprofile = new PlayerProfile()
            {
                ID = dto.ID,
                ApplicationUserID = dto.ApplicationUserID,
                ScreenName = "",
                Victories = 0,
                CurrentStatus = ProfileStatus.Active,
                ProfileType = false,
                ProfileStatusLastChangedAt = DateTime.UtcNow,
                ProfileAttributedToAnAccountUserAt = DateTime.UtcNow,
                ProfileCreatedAt = DateTime.UtcNow,
                ProfileModifiedAt = DateTime.UtcNow,
            };
            var result = await _context.PlayerProfiles.AddAsync(newprofile);
            if (result != null)
            {
                List<string> errordatas =
                       [
                       "Area", "Accounts",
                       "Issue", "Failure",
                       "StatusMessage", "Creation of Player profile is unsuccessful. \nPlease contact an Administrator.",
                       "UserID", $"{newprofile.ApplicationUserID}",
                       "PlayerProfileID", $"{newprofile.ID}"
                       ];
                ViewBag.ErrorDatas = errordatas;
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            return View("~/Views/Home/Index.cshtml");
        }
        [HttpGet]
        public async Task<IActionResult> NewPlayerProfile()
        {
            return View();
        }
    }
}
