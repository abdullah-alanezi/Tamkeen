using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tamkeen.Application.Interfaces;
using Tamkeen.Domain.Entities;
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


        public async Task<List<Domain.Entities.TrainingProgram>> GetAllAsync()
        {
            
            return await _context.TrainingPrograms.ToListAsync();
        }

        public async Task<Domain.Entities.TrainingProgram?> GetByIdAsync(int id)
        {
            return await _context.TrainingPrograms.FindAsync(id);
        }

        public Task<Domain.Entities.TrainingProgram?> GetByPublicIdAsync(Guid publicId)
        {
            throw new NotImplementedException();
        }

        public async Task MakePosted(int id)
        {
            var program = await _context.TrainingPrograms.FindAsync(id);
            if (program != null)
              program.is_posted = true;

           await _context.SaveChangesAsync();
        }

        public async Task Update(Domain.Entities.TrainingProgram entity)
        {
            var trackedProgram = await _context.TrainingPrograms
                .FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (trackedProgram != null)
            {
                // نسخ القيم
                _context.Entry(trackedProgram).CurrentValues.SetValues(entity);

                // أخبر EF ألا يقوم بتحديث هذا الحقل تحديداً
                _context.Entry(trackedProgram).Property(x => x.is_posted).IsModified = false;

                await _context.SaveChangesAsync();
            }
        }
    }
}
