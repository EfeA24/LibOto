using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.NewFolder;

namespace Presentation.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<User> _userManager;
        private RoleManager<AssignRole> _roleManager;
        private SignInManager<User> _signinManager;
        public AccountController(
            UserManager<User> userManager,
            RoleManager<AssignRole> roleManager,
            SignInManager<User> signinManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    await _signinManager.SignOutAsync();

                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError("", "Please confirm your account via e-mail");
                        return View(model);
                    }

                    var result = await _signinManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);
                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);
                        await _userManager.SetLockoutEndDateAsync(user, null);

                        return RedirectToAction(nameof(Index), "Home");
                    }
                    else if (result.IsLockedOut)
                    {
                        var logoutDate = await _userManager.GetLockoutEndDateAsync(user);
                        var timeLeft = DateTime.Now - logoutDate;

                        ModelState.AddModelError("", $"Your account has been locked for {timeLeft}");
                    }

                    else
                    {
                        ModelState.AddModelError("", "Incorrect Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Can't find an account registired to e-mail");
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }

}