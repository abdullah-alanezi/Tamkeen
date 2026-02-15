using Tamkeen.Application.Interfaces.IBaseRepository;
using Tamkeen.Domain.Entities;

namespace Tamkeen.Application.Interfaces
{
    public interface IProgramEnrollmentRepository : IBaseRepository<ProgramEnrollment>
    {
        Task<List<ProgramEnrollment>> GetByTraineeIdAsync(int traineeId);

        Task<List<ProgramEnrollment>> GetByManagerIdAsync(int managerId);
    }
}
