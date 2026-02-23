
using Tamkeen.Domain.Entities;

namespace Tamkeen.Application.Interfaces
{
    public interface IProgramPostRepository
    {

        Task PostAsync(int programId);

        Task<List<ProgramPost>> GetAllPostsWithProgramAsync();
        Task<ProgramPost?> GetWithDetailsAsync(int id);

    }
}
