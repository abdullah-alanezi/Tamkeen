using Tamkeen.Domain.Entities.Base;

namespace Tamkeen.Domain.Entities
{
    public class AttendanceRecord:BaseEntity
    {
        public int EnrollmentId { get; set; }
        public ProgramEnrollment Enrollment { get; set; }

        public DateTime Date { get; set; }

        public bool IsPresent { get; set; }

        public string? Notes { get; set; }
    }
}
