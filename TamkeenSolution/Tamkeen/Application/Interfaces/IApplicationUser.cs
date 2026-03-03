using Tamkeen.Domain.Entities;

namespace Tamkeen.Application.Interfaces
{
    public interface IApplicationUser
    {

        Task<List<ApplicationUser>> GetAllAsync();
    }
}
