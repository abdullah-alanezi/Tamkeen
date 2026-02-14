using Microsoft.AspNetCore.Identity;

namespace Tamkeen.Domain.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FullName { get; set; }

        public string? NationalId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? ProfileImagePath { get; set; }

        // Navigation
        public Trainee? TraineeProfile { get; set; }
    }
}
