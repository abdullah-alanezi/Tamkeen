using Tamkeen.Application.Interfaces.IBaseRepository;
using Tamkeen.Domain.Entities;

namespace Tamkeen.Application.Interfaces
{
    public interface IProgramEnrollmentRepository : IBaseRepository<ProgramEnrollment>
    {
        Task<IReadOnlyList<ProgramEnrollment>> GetByTraineeIdAsync(int traineeId);

        Task<IReadOnlyList<ProgramEnrollment>> GetByManagerIdAsync(int managerId);
    }
}
