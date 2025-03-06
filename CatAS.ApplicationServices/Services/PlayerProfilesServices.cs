
using Cat.Core.Domain;
using Cat.Core.ServiceInterface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.ApplicationServices.Services
{
    public class PlayerProfilesServices : IPlayerProfilesServices
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public PlayerProfilesServices 
            (
                UserManager<ApplicationUser> userManager
            )
        {
            _userManager = userManager;
        }
        public async Task<PlayerProfile> Create(string useridfor)
        {
            var user = await _userManager.FindByIdAsync(useridfor);
            string userid = user.Id;
            var profile = new PlayerProfile
            {
                ID = new Guid(),
                ApplicationUserID = userid,
                ScreenName = "",
                CurrentStatus = ProfileStatus.Active,
                Gold = 0,
                Momentos = 0,
                MyCharacters = new List<KittyOwnership>(),
                ProfileType = false,
                Victories = 0,
            };
            return profile;
        }
    }
}
