using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tamkeen.Application.Interfaces;
using Tamkeen.Domain.Entities;
using Tamkeen.Infrastructure.Database;

namespace Tamkeen.Infrastructure.Repository
{
    public class EvaluationRepo : IEvaluationRepository
    {
        private readonly ApplicationDbContext _context;

        public EvaluationRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Evaluation entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Evaluation entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Evaluation>> FindAsync(Expression<Func<Evaluation, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Evaluation>> GetAllAsync()
        {
            return await _context.Evaluations.ToListAsync();
        }

        public Task<List<Evaluation>> GetByEnrollmentIdAsync(int enrollmentId)
        {
            throw new NotImplementedException();
        }

        public Task<Evaluation?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Evaluation?> GetByPublicIdAsync(Guid publicId)
        {
            throw new NotImplementedException();
        }

        public void Update(Evaluation entity)
        {
            throw new NotImplementedException();
        }
    }
}
