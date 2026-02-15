using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tamkeen.Application.Interfaces;
using Tamkeen.Infrastructure.Database;

namespace Tamkeen.Infrastructure.Repository
{
    public class TrainingProgramRepo : ITrainingProgramRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainingProgramRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Domain.Entities.TrainingProgram entity)
        {
            if (entity == null)
            {
                throw new NotImplementedException("Enter the program");
            }
            else
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

            }
        }

        public void Delete(Domain.Entities.TrainingProgram entity)
        {
            if (entity == null) 
            throw new NotImplementedException();
            else { _context.Remove(entity); 
                    _context.SaveChanges();
            
            }
                    
        }

        public Task<List<Domain.Entities.TrainingProgram>> FindAsync(Expression<Func<Domain.Entities.TrainingProgram, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.TrainingProgram>> GetActiveProgramsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Domain.Entities.TrainingProgram>> GetAllAsync()
        {
            
            return await _context.TrainingPrograms.ToListAsync();
        }

        public Task<Domain.Entities.TrainingProgram?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.TrainingProgram?> GetByPublicIdAsync(Guid publicId)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.TrainingProgram entity)
        {
            throw new NotImplementedException();
        }
    }
}
