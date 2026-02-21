using Microsoft.AspNetCore.Identity;

namespace Tamkeen.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser<int>>> GetAllUsersAsync();
        Task<IdentityUser<int>> GetUserByIdAsync(int userId);
        Task<bool> UpdateUserRoleAsync(int userId, string newRole);
        Task<bool> DeleteUserAsync(int userId);
        Task<string> GetUserRoleAsync(IdentityUser<int> user);
    }
}
