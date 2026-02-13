using Tamkeen.Domain.Entities.Base;
using Tamkeen.Domain.Enums;

namespace Tamkeen.Domain.Entities
{
    public class Evaluation:BaseEntity
    {
        public int EnrollmentId { get; set; }
        public ProgramEnrollment Enrollment { get; set; }

        public int EvaluatedById { get; set; }
        public ApplicationUser EvaluatedBy { get; set; }

        public int Score { get; set; } // 0 - 100

        public string Feedback { get; set; }

        public EvaluationType Type { get; set; }
    }
}
