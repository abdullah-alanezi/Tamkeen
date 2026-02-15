using Tamkeen.Application.Interfaces.IBaseRepository;
using Tamkeen.Domain.Entities;

namespace Tamkeen.Application.Interfaces
{
    public interface IAttendanceRepository : IBaseRepository<AttendanceRecord>
    {
        Task<List<AttendanceRecord>> GetByEnrollmentIdAsync(int enrollmentId);
    }
}
