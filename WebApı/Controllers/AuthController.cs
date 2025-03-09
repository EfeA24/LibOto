using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Entities.Models;
using Services.Contracts;

namespace WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (success, message) = await _authService.LoginAsync(model);
            if (!success)
                return Unauthorized(new { Message = message });

            return Ok(new { Message = message });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return Ok(new { Message = "Çıkış yapıldı" });
        }
    }
}
