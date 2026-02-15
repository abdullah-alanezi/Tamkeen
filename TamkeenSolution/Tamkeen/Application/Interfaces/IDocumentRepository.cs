using Tamkeen.Application.Interfaces.IBaseRepository;
using Tamkeen.Domain.Entities;

namespace Tamkeen.Application.Interfaces
{
    public interface IDocumentRepository : IBaseRepository<Document>
    {
        Task<List<Document>> GetByTraineeIdAsync(int traineeId);
    }
}
