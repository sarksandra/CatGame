using Cat.Core.Domain;
using Cat.Core.Dto.AccountsDtos;
using Cat.Core.ServiceInterface;
using Microsoft.AspNetCore.Identity;


namespace Cat.ApplicationServices.Services
{
    public class AccountsServices : IAccountsServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly IPlayerProfilesServices _playerProfilesServices;
        private readonly IEmailsServices _emailsServices;

        public AccountsServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailsServices emailsServices,IPlayerProfilesServices playerProfilesServices)
        {
            _userManager = userManager;
            _SignInManager = signInManager;
            _emailsServices = emailsServices;
            _playerProfilesServices = playerProfilesServices;
        }

        public async Task<ApplicationUser> Register(ApplicationUserDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.Username,
                Email = dto.Email,
                City = dto.City,
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            }
            await _playerProfilesServices.Create((string)user.Id);
            return user;
        }

        public async Task<ApplicationUser>ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByNameAsync(userId);
            if(user == null)
            {
                string errorMessage = $"User with id {userId} is not valid";
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return user;
        }

        public async Task<ApplicationUser> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            return user;
        }
    }
}
