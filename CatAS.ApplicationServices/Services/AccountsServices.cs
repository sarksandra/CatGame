using Cat.Core.Domain;
using Cat.Core.Dto.AccountsDtos;
using Cat.Core.ServiceInterface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.ApplicationServices.Services
{
    public class AccountsServices : IAccountsServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IPlayerProfilesServices _playerProfilesServices;

        public AccountsServices
            (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IPlayerProfilesServices playerProfilesServices
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _playerProfilesServices = playerProfilesServices;
        }
        public async Task<ApplicationUser> Register(ApplicationUserDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                City = dto.City,
                ProfileType = false,
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            }
            return user;
        } 
        public async Task<ApplicationUser> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                string errorMessage = $"User with id ${userId} is not valid.";
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
