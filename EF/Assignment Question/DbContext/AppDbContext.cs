using Microsoft.EntityFrameworkCore;

namespace EFCoreConsoleApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
