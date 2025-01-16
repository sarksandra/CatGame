﻿using Cat.Core.Domain;
using Cat.Core.Dto.AccountDtos;
using Cat.Core.ServiceInterFace;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.ApplicationServices.Service
{
    public class AccountsServices : IAccountsServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IPlayerProfilesServices _playerProfilesServices;


        public AccountsServices
            (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<ApplicationUser> Register(ApplicationUserDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                City = dto.City,
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if(result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            }
            return user;
        }
        public async Task<ApplicationUser> ConfirmedEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                string errorMassage = $"User with id {user} is not valid.";

            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return user;
        }
        public async Task<ApplicationUser> LogIn(LogInDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            return user;
        }
    }
}
