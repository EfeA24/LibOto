using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService) => _roleService = roleService;

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return BadRequest("Role name cannot be empty.");

            var result = await _roleService.CreateRoleAsync(roleName);
            return result.Succeeded ? CreatedAtAction(nameof(GetRole), new { roleName }, roleName)
                                    : BadRequest(result.Errors);
        }

        [HttpGet("{roleName}")]
        public async Task<IActionResult> GetRole(string roleName)
        {
            var role = await _roleService.GetRoleByNameAsync(roleName);
            return role != null ? Ok(role) : NotFound($"Role '{roleName}' not found.");
        }

        [HttpGet]
        public IActionResult GetAllRoles() => Ok(_roleService.GetAllRoles());

        [HttpDelete("{roleName}")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var result = await _roleService.DeleteRoleAsync(roleName);
            
            return result.Succeeded ? NoContent() : BadRequest(result.Errors);
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] AssignRole model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.UserId) || string.IsNullOrWhiteSpace(model.RoleName))
                
                return BadRequest("User ID and Role Name cannot be empty.");

            var result = await _roleService.AssignRoleToUserAsync(model.UserId, model.RoleName);
            
            return result.Succeeded ? NoContent() : BadRequest(result.Errors);
        }
    }
}
