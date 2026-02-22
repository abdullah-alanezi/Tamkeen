using System.ComponentModel.DataAnnotations;

namespace Tamkeen.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "UserName is required")]
        [Display(Name = "UserName")]

        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
