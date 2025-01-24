using Cat.Core.Domain;
using Cat.Core.ServiceInterface;
using Microsoft.AspNetCore.Identity;


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
            var profile = new PlayerProfile()
            {
                ID = new Guid(),
                ApplicationUserID = userid,
                ScreenName = "",
                HunterCredits = 100,
                Victories = 0,
                CurrentStatus = ProfileStatus.Active,
                ProfileType = false,
                ProfileStatusLastChangedAt = DateTime.UtcNow,
                ProfileAttributedToAnAccountUserAt = DateTime.UtcNow,
                ProfileCreatedAt = DateTime.UtcNow,
                ProfileModifiedAt = DateTime.UtcNow,
            };
            return profile;
        }
    }
}
