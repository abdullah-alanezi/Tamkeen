using Tamkeen.Application.Interfaces.IBaseRepository;
using Tamkeen.Domain.Entities;
using Tamkeen.Domain.Enums;

namespace Tamkeen.Application.Interfaces
{
    public interface ITraineeRepository : IBaseRepository<Trainee>
    {
        Task<Trainee?> GetWithDetailsAsync(int id);

        Task<IReadOnlyList<Trainee>> GetByStatusAsync(TraineeStatus status);

        Task<Trainee?> GetByUserIdAsync(int userId);
    }
}
