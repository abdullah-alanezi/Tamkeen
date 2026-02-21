using Microsoft.AspNetCore.Identity;

namespace Tamkeen.Infrastructure.Roles
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAndUsers(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser<int>>>();

            
            string[] roleNames = { "Admin", "HR", "Manager", "Trainee" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    
                    await roleManager.CreateAsync(new IdentityRole<int>(roleName));
                }
            }

            
            var adminEmail = "admin@tamkeen.com";
            var user = await userManager.FindByEmailAsync(adminEmail);

            if (user == null)
            {
                var adminUser = new IdentityUser<int>
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                };

                var createPowerUser = await userManager.CreateAsync(adminUser, "Admin@123");

                if (createPowerUser.Succeeded)
                {
                  
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}