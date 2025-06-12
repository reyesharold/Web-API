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

            modelBuilder.Entity<StudentSubject>()
                .HasKey(compKey => new { compKey.StudentId, compKey.SubjectId });

            modelBuilder.Entity<StudentSubject>()
                .HasOne(s => s.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(s => s.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(s => s.SubjectId);

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
