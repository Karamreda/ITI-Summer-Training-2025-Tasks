using EFCoreConsoleApp.Models;

public class Course
{
    public int Id { get; set; }
    public string CourseName { get; set; } = string.Empty;

   
    public ICollection<Student>? Students { get; set; }
}
