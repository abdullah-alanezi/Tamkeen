using Tamkeen.Domain.Entities.Base;

namespace Tamkeen.Domain.Entities
{
    public class TrainingProgram:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int Capacity { get; set; }

        public ProgramPost programPost { get; set; }
        // Navigation

        public bool is_posted { get; set; }
        public ICollection<ProgramEnrollment> Enrollments { get; set; }
    }
}
