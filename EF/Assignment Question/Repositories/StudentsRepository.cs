using EFCoreConsoleApp.Data;

using Microsoft.EntityFrameworkCore;

public class StudentsRepository
{
    private readonly AppDbContext _context;

    public StudentsRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddStudent(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
    }

    public List<Student> GetAllStudentsWithCourse()
    {
        return _context.Students.Include(s => s.Course).ToList();
    }

    public List<Student> GetStudentsByCourse(int courseId)
    {
        return _context.Students.Include(s => s.Course)
                                .Where(s => s.CourseId == courseId)
                                .ToList();
    }
}
