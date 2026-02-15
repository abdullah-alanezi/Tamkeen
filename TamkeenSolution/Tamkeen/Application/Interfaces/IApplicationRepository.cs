using Tamkeen.Application.Interfaces.IBaseRepository;
using Tamkeen.Domain.Enums;
using Tamkeen.Domain.Entities;
namespace Tamkeen.Application.Interfaces
{
    public interface IApplicationRepository : IBaseRepository<Tamkeen.Domain.Entities.Application>
    {
        Task<List<Tamkeen.Domain.Entities.Application>> GetByStatusAsync(ApplicationStatus status);

        Task<Tamkeen.Domain.Entities.Application?> GetByEmailAsync(string email);
    }
}
