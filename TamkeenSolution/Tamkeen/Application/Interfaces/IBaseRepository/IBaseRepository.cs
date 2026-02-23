using System.Linq.Expressions;

namespace Tamkeen.Application.Interfaces.IBaseRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);

        Task<T?> GetByPublicIdAsync(Guid publicId);

        Task<List<T>> GetAllAsync();

       

        Task AddAsync(T entity);

        Task Update(T entity);

        void Delete(T entity);

        //Task<int> SaveChangesAsync();
    }
}
