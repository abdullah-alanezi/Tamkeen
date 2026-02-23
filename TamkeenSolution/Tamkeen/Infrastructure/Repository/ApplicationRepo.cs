using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tamkeen.Application.Interfaces;
using Tamkeen.Domain.Entities;
using Tamkeen.Domain.Enums;
using Tamkeen.Infrastructure.Database;
using Tamkeen.Infrastructure.Services;

namespace Tamkeen.Infrastructure.Repository
{
    public class ApplicationRepo : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly TraineeAccountService _traineeAccountService;
        public ApplicationRepo(ApplicationDbContext context, TraineeAccountService traineeAccountService)
        {
            _context = context;
            _traineeAccountService = traineeAccountService;
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



        public async Task<List<Domain.Entities.Application>> GetAllAsync()
        {
            var Application = await _context.Applications.ToListAsync();

            return Application;

        }

        public Task<Domain.Entities.Application?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Entities.Application?> GetByIdAsync(int id)
        {
            return await _context.Applications.FindAsync(id);
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

        public Task Update(Domain.Entities.Application entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateStatus(int id, ApplicationStatus status)
        {
            var application = await _context.Applications.FindAsync(id);

            if (application == null)
                throw new Exception("Application not found");


            application.Status = status;


            // اذا Accepted
            if (status == ApplicationStatus.Accepted)
            {
                await _traineeAccountService.CreateTraineeAccountAsync(application);
            }


            await _context.SaveChangesAsync();
        }
    }
}
