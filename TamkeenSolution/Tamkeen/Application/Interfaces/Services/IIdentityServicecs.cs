namespace Tamkeen.Application.Interfaces.Services
{
    public interface IIdentityService
    {
        Task<int> CreateUserAsync(string email, string password, string fullName, string role);

        Task<bool> AssignRoleAsync(int userId, string role);

        Task<bool> CheckPasswordAsync(string email, string password);

        Task<string> GenerateJwtTokenAsync(int userId);
    }
}
