
namespace EFCoreConsoleApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}

