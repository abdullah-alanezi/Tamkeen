using Microsoft.AspNetCore.Identity;
using Tamkeen.Application.Interfaces;
using Tamkeen.Domain.Entities;
using Tamkeen.Infrastructure.Database;

namespace Tamkeen.Infrastructure.Services
{
    public class TraineeAccountService
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ITraineeRepository _traineeRepo;

        public TraineeAccountService(
            UserManager<IdentityUser<int>> userManager,
            ApplicationDbContext context,
            ITraineeRepository traineeRepo

            )
        {
            _userManager = userManager;
            _context = context;
            _traineeRepo = traineeRepo;
        }


        public async Task CreateTraineeAccountAsync(Tamkeen.Domain.Entities.Application application)
        {
            // تحقق هل المستخدم موجود
            var existUser =
                await _userManager.FindByEmailAsync(application.Email);

            if (existUser != null)
                return;


            // إنشاء Identity User
            var identityUser = new IdentityUser<int>
            {
                UserName = application.Email,
                Email = application.Email,
                EmailConfirmed = true
            };


            var result =
                await _userManager.CreateAsync(identityUser, "Temp@123");


            if (!result.Succeeded)
                throw new Exception("User Create Failed");


            // إعطاء Role
            await _userManager.AddToRoleAsync(identityUser, "Trainee");


            // إنشاء ApplicationUser
            var appUser = new ApplicationUser
            {
                FullName = application.FullName,
                UserId = identityUser.Id
            };


            await _context.ApplicationUsers.AddAsync(appUser);

            var trainee = new Trainee
            {
                User = appUser,

            };

            await _traineeRepo.AddAsync(trainee);

            
        }
    }
}
