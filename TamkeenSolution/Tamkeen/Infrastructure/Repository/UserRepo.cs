using Microsoft.AspNetCore.Identity;
using Tamkeen.Application.Interfaces;

namespace Tamkeen.Infrastructure.Repository
{
    public class UserRepo : IUserRepository
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public UserRepo(UserManager<IdentityUser<int>> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<IdentityUser<int>>> GetAllUsersAsync() =>
            await Task.FromResult(_userManager.Users.ToList());

        public async Task<IdentityUser<int>> GetUserByIdAsync(int userId) =>
            await _userManager.FindByIdAsync(userId.ToString());

        public async Task<string> GetUserRoleAsync(IdentityUser<int> user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.FirstOrDefault() ?? "No Role";
        }

        public async Task<bool> UpdateUserRoleAsync(int userId, string newRole)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;

            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles); 
            var result = await _userManager.AddToRoleAsync(user, newRole); 

            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }
}
