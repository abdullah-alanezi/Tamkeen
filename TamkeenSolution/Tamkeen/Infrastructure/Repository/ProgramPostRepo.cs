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

        public void Post(int programId)
        {
            
            var program = _context.TrainingPrograms.Find(programId);

            var Post = new ProgramPost();

            Post.trainingProgram = program;
          

            _context.Add(Post);
            _context.SaveChanges();

        }
    }
}
