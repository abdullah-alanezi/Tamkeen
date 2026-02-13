using Tamkeen.Application.Interfaces.IBaseRepository;
using Tamkeen.Domain.Entities;

namespace Tamkeen.Application.Interfaces
{
    public interface IDocumentRepository : IBaseRepository<Document>
    {
        Task<IReadOnlyList<Document>> GetByTraineeIdAsync(int traineeId);
    }
}
