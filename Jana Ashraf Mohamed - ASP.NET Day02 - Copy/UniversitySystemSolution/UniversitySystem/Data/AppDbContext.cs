using Microsoft.EntityFrameworkCore;
using UniversitySystem.Models;

namespace UniversitySystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StuCrsRes> StuCrsResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StuCrsRes>()
                .HasKey(x => new { x.StudentId, x.CourseId });

            modelBuilder.Entity<Teacher>()
                .Property(t => t.Salary)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Department)
                .WithMany(d => d.Teachers)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StuCrsRes>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StuCrsResults)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}