using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tamkeen.Domain.Entities;
using Tamkeen.Domain.Enums;

namespace Tamkeen.Infrastructure.Database
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
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
        public DbSet<ProgramPost> ProgramPosts { get; set; }
        public DbSet<Evaluation> Evaluations {  get; set; }
        public DbSet<ApplicationUser> ApplicationUsers {  get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Trainee>(entity=> {
                entity.HasOne(p => p.User).WithOne(p => p.TraineeProfile).OnDelete(DeleteBehavior.Cascade);
                entity.HasMany(x => x.Documents).WithOne(x => x.Trainee).OnDelete(DeleteBehavior.Restrict);
                entity.HasMany(x => x.Enrollments).WithOne(x => x.Trainee).OnDelete(DeleteBehavior.Restrict);
                entity.Property(x=>x.Status).HasDefaultValue(TraineeStatus.Applicant);
                }
                );

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasOne(a => a.UserInfo)
                      .WithOne()
                      .HasForeignKey<ApplicationUser>(a => a.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            //modelBuilder.Entity<Tamkeen.Domain.Entities.Application>(entity =>
            //{
            //    entity.Property(x => x.Status).HasDefaultValue(ApplicationStatus.Pending);

            //});

            modelBuilder.Entity<ProgramPost>(entity => {

                entity.HasOne(x => x.trainingProgram).WithOne(x => x.programPost).HasForeignKey<ProgramPost>(x=>x.programId).OnDelete(DeleteBehavior.SetNull);
                entity.HasMany(x => x.application).WithOne(x => x.programPost).OnDelete(DeleteBehavior.Restrict);
            
            });

            modelBuilder.Entity<TrainingProgram>(entity => {
            entity.Property(x=>x.is_posted).HasDefaultValue(false);
            });

        }
    }
}
