using Microsoft.EntityFrameworkCore;

namespace Tamkeen.Infrastructure.Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
    }
}
