using System.Threading.Tasks;
using Entities.Models;

namespace Services.Contracts
{
    public interface IAuthService
    {
        Task<(bool Success, string Message)> LoginAsync(LoginModel model);
        Task LogoutAsync();
    }
}
