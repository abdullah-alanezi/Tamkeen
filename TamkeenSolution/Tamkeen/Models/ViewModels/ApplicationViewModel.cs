using System.ComponentModel.DataAnnotations;

namespace Tamkeen.Models.ViewModels
{
    public class ApplicationViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string University { get; set; }

        [Required]
        public string Major { get; set; }

        [Required]
        public IFormFile CVFile { get; set; }

        public int ProgramPostId { get; set; }
    }
}
