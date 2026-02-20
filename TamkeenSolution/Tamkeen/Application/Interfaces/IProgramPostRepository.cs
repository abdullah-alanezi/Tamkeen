
using Tamkeen.Domain.Entities;

namespace Tamkeen.Application.Interfaces
{
    public interface IProgramPostRepository
    {

        void Post(int programId);

        Task<List<ProgramPost>> GetAllPostsWithProgramAsync();
        Task<ProgramPost?> GetWithDetailsAsync(int id);

    }
}
