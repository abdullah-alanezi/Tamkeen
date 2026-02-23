using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using Tamkeen.Application.Interfaces;
using Tamkeen.Application.Interfaces.IBaseRepository;
using Tamkeen.Domain.Entities;
using Tamkeen.Domain.Enums;
using Tamkeen.Infrastructure.Database;

namespace Tamkeen.Infrastructure.Repository
{
    public class TraineeRepo : ITraineeRepository  

    {
        private readonly ApplicationDbContext _context;

        public TraineeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Trainee entity)
        {
            if (entity == null)
            {
                throw new NotImplementedException("Please Enter Trainee");
            }
            else
            {
               await  _context.AddAsync(entity);
               await _context.SaveChangesAsync();
            }
        }

        public void Delete(Trainee entity)
        {
            if (entity == null)
            {
                throw new NotImplementedException("Please Enter Trainee");
            }
            else
            {
                 _context.Remove(entity);
                 _context.SaveChangesAsync();
            }
        }



        public  async Task<List<Trainee>> GetAllAsync()
        {
            var Trainees = await _context.Trainees.Include(x=>x.User).ToListAsync();

            return Trainees;
        }

        public async Task<Trainee?> GetByIdAsync(int id)
        {
            var trainee = await _context.Trainees.FindAsync(id);

            return trainee;
        }

        public Task<Trainee?> GetByPublicIdAsync(Guid publicId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Trainee>> GetByStatusAsync(TraineeStatus status)
        {
            return await _context.Trainees.Where(x=>x.Status == status).ToListAsync();
        }

        public async Task<Trainee?> GetByUserIdAsync(int userId)
        {
            var trainee = await _context.Trainees.FindAsync(userId);

            return trainee;
        }

        public async Task<Trainee?> GetWithDetailsAsync(int id)
        {
            var trainee = await _context.Trainees.Include(x=>x.User).Include(x=>x.Documents).Include(x=>x.Enrollments).FirstOrDefaultAsync(x=>x.Id == id);
            return trainee;
        }

        //public Task<int> SaveChangesAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task Update(Trainee entity)
        {
            var trainee = await _context.Trainees.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (entity == null || trainee == null)
            {
                throw new NotImplementedException("Trainee Not Found");
            }
            else 
            {
                trainee.User = entity.User;
                trainee.Documents = entity.Documents;
                trainee.Major = entity.Major;
                trainee.Status = entity.Status;
                trainee.Enrollments = entity.Enrollments;
                trainee.GPA = entity.GPA;
                trainee.University = entity.University;

                _context.Trainees.Update(trainee);
                await _context.SaveChangesAsync();
            }
        }






    }
}
