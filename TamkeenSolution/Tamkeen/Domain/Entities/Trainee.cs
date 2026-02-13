using System.Reflection.Metadata;
using Tamkeen.Domain.Entities.Base;
using Tamkeen.Domain.Enums;

namespace Tamkeen.Domain.Entities
{
    public class Trainee:BaseEntity
    {
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string University { get; set; }
        public string Major { get; set; }
        public double GPA { get; set; }

        public TraineeStatus Status { get; set; }

        // Navigation
        public ICollection<ProgramEnrollment> Enrollments { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
