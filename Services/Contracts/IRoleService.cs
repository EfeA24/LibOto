using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IRoleService
    {
        Task<IdentityRole> GetRoleByNameAsync(string roleName);
        IEnumerable<IdentityRole> GetAllRoles();
        Task<bool> RoleExistsAsync(string roleName);
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<IdentityResult> DeleteRoleAsync(string roleName);
        Task<IdentityResult> AssignRoleToUserAsync(string userId, string roleName);
    }
}
