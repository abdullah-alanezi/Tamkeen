using System.ComponentModel.DataAnnotations;
using Tamkeen.Domain.Entities.Base;
using Tamkeen.Domain.Enums;

namespace Tamkeen.Domain.Entities
{
    public class Application : BaseEntity
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
        public string CVPath { get; set; }

        public int programPostId { get; set; }
        public ProgramPost programPost { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
