using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Services.Contracts;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(SignInManager<User> signInManager, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<(bool Success, string Message)> LoginAsync(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return (false, "Kullanıcı bulunamadı.");

            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!isPasswordValid)
                return (false, "Geçersiz kullanıcı adı veya şifre.");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties { IsPersistent = true };

            await _httpContextAccessor.HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
                                                               new ClaimsPrincipal(claimsIdentity),
                                                               authProperties);

            return (true, "Giriş başarılı");
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
