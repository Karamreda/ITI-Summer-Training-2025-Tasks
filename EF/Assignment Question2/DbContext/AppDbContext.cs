using Microsoft.EntityFrameworkCore;
using EFCoreConsoleApp.Models;

namespace EFCoreConsoleApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=StudentCourseDb;Trusted_Connection=True;");
        }
    }
}
