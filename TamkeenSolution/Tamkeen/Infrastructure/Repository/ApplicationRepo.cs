using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tamkeen.Application.Interfaces;
using Tamkeen.Domain.Enums;
using Tamkeen.Infrastructure.Database;

namespace Tamkeen.Infrastructure.Repository
{
    public class ApplicationRepo : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Domain.Entities.Application entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(Domain.Entities.Application entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.Application>> FindAsync(Expression<Func<Domain.Entities.Application, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Domain.Entities.Application>> GetAllAsync()
        {
            var Application = await _context.Applications.ToListAsync();

            return Application;

        }

        public Task<Domain.Entities.Application?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Application?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Application?> GetByPublicIdAsync(Guid publicId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Domain.Entities.Application>> GetByStatusAsync(ApplicationStatus status)
        {
            var appBystatus = await _context.Applications.Where(x=>x.Status == status).ToListAsync();

            return appBystatus;
        }

        public void Update(Domain.Entities.Application entity)
        {
            throw new NotImplementedException();
        }
    }
}
