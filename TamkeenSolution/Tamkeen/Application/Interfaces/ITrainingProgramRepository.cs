using Tamkeen.Application.Interfaces.IBaseRepository;
using Tamkeen.Domain.Entities;

namespace Tamkeen.Application.Interfaces
{
    public interface ITrainingProgramRepository : IBaseRepository<TrainingProgram>
    {
        
        Task MakePosted(int id);
    }
}
