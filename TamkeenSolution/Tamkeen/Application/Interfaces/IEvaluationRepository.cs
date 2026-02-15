using Tamkeen.Application.Interfaces.IBaseRepository;
using Tamkeen.Domain.Entities;

namespace Tamkeen.Application.Interfaces
{
    public interface IEvaluationRepository : IBaseRepository<Evaluation>
    {
        Task<List<Evaluation>> GetByEnrollmentIdAsync(int enrollmentId);
    }
}
