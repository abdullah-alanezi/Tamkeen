using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tamkeen.Application.Interfaces;
using Tamkeen.Models.ModelsView;

namespace Tamkeen.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public UserController(IUserRepository userRepo, RoleManager<IdentityRole<int>> roleManager)
        {
            _userRepo = userRepo;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userRepo.GetAllUsersAsync();
            var userRolesList = new List<UserRolesViewModel>();
            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();

            foreach (var user in users)
            {
                userRolesList.Add(new UserRolesViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    CurrentRole = await _userRepo.GetUserRoleAsync(user),
                    AllRoles = allRoles
                });
            }
            return View(userRolesList);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(int userId, string newRole)
        {
            var success = await _userRepo.UpdateUserRoleAsync(userId, newRole);
            if (success) return RedirectToAction("Index");
            return BadRequest("somthing went Wrong");
        }
    }
}
