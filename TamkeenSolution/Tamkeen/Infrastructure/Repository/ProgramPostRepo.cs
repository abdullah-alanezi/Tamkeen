using Microsoft.EntityFrameworkCore;
using Tamkeen.Application.Interfaces;
using Tamkeen.Domain.Entities;
using Tamkeen.Infrastructure.Database;

namespace Tamkeen.Infrastructure.Repository
{
    public class ProgramPostRepo:IProgramPostRepository
    {

        private readonly ApplicationDbContext _context;

        public ProgramPostRepo(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<List<ProgramPost>> GetAllPostsWithProgramAsync()
        {
            var PostProgram = await _context.ProgramPosts.Include(x => x.trainingProgram).ToListAsync();
            return PostProgram;
        }


        public async Task<ProgramPost?> GetWithDetailsAsync(int id)
        {
            var PostProgram = await _context.ProgramPosts.Include(x => x.trainingProgram).Include(x => x.application).FirstOrDefaultAsync(x=>x.Id == id);



            return PostProgram;
        }

        public async Task PostAsync(int programId)
        {
            
            var program = await _context.TrainingPrograms.FindAsync(programId);

            var Post = new ProgramPost();

            if (program != null)
            {
                Post.trainingProgram = program;
                await _context.AddAsync(Post);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Failed To Post Program");
            }
          



        }
    }
}
