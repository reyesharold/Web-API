using ApiFirstProj.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiFirstProj.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Subjects)
                .WithMany(s => s.Students);

            modelBuilder.Entity<Subject>()
                .HasOne(p => p.Professor)
                .WithMany(s => s.Subjects)
                .HasForeignKey(p => p.ProfessorId);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; } 
        public DbSet<Subject> Subjects { get; set; }
    }
}
