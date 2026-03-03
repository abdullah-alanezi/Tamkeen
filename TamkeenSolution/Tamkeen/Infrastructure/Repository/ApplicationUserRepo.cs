using Microsoft.EntityFrameworkCore;
using Tamkeen.Application.Interfaces;
using Tamkeen.Domain.Entities;
using Tamkeen.Infrastructure.Database;

namespace Tamkeen.Infrastructure.Repository
{
    public class ApplicationUserRepo : IApplicationUser

    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ApplicationUser>> GetAllAsync()
        {
            return await _context.applicationUsers.ToListAsync();
        }
    }
}
