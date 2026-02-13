using Tamkeen.Domain.Entities.Base;
using Tamkeen.Domain.Enums;

namespace Tamkeen.Domain.Entities
{
    public class ProgramEnrollment:BaseEntity
    {
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }

        public int ProgramId { get; set; }
        public TrainingProgram Program { get; set; }

        public int? ManagerId { get; set; }
        public ApplicationUser? Manager { get; set; }

        public EnrollmentStatus Status { get; set; }

        // Navigation
        public ICollection<Evaluation> Evaluations { get; set; }
        public ICollection<AttendanceRecord> AttendanceRecords { get; set; }
    }
}
