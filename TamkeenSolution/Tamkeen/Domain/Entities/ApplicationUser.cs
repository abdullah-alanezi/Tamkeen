using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Tamkeen.Domain.Entities
{
    public class ApplicationUser //: IdentityUser<int>
    {

        [Key]
        public int Id {  get; set; }
        public string FullName { get; set; }

        public string? NationalId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? ProfileImagePath { get; set; }

        // Navigation
        public Trainee? TraineeProfile { get; set; }


        public Guid? UserId { get; set; }

        public IdentityUser UserInfo { get; set; }



    }
}
