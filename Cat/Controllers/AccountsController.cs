using Cat.Core.Domain;
using Cat.Models.Accounts;
using CatGame.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Cat.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly KittyGameContext _context;


        public AccountsController
            (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            KittyGameContext context

            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> AddPassword()
        {
            var user = await _userManager.GetUserAsync(User);
            var userHasPassword = await _userManager.HasPasswordAsync(user);
            if(userHasPassword)
            {
                RedirectToAction("ChangePassword");
            }
            return View();

        }




        [HttpPost]
        public async Task<IActionResult> AddPassword (AddPasswordViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _userManager.AddPasswordAsync(user, model.NewPassword);
                if (result.Succeeded) 
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);

                    }
                    return View();
                }
                await _signInManager.RefreshSignInAsync(user);
                return View("AddPassWordConfirmation");
            }
            return View(model);
        }
    }
}
