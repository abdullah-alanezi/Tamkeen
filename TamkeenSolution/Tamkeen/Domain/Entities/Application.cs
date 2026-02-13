using Tamkeen.Domain.Entities.Base;
using Tamkeen.Domain.Enums;

namespace Tamkeen.Domain.Entities
{
    public class Application : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public string University { get; set; }
        public string Major { get; set; }

        public string CVPath { get; set; }

        public ApplicationStatus Status { get; set; }
    }
}
