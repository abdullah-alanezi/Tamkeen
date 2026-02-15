using Microsoft.EntityFrameworkCore;
using Tamkeen.Domain.Entities;
using Tamkeen.Domain.Enums;

namespace Tamkeen.Infrastructure.Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<ProgramEnrollment> programEnrollments { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Tamkeen.Domain.Entities.Application> Applications { get; set; }
        public DbSet<TrainingProgram> TrainingPrograms {  get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainee>(entity=> {
                entity.HasOne(p => p.User).WithOne(p => p.TraineeProfile).OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(x => x.Documents).WithOne(x => x.Trainee).OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(x => x.Enrollments).WithOne(x => x.Trainee).OnDelete(DeleteBehavior.Restrict);
                }
                );
            modelBuilder.Entity<Tamkeen.Domain.Entities.Application>(entity =>
            {
                entity.Property(x => x.Status).HasDefaultValue(ApplicationStatus.Pending);

            });

        }
    }
}
