using EFCoreConsoleApp.Data;
using EFCoreConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreConsoleApp.Repositories
{
    public class StudentsRepository
    {
        private readonly AppDbContext _context;

        public StudentsRepository(AppDbContext context)
        {
            _context = context;
        }
     
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<Student> GetAllStudentsWithCourse()
        {
            return _context.Students.Include(s => s.Course).ToList();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public List<Student> GetStudentsByCourse(int courseId)
        {
            return _context.Students
                .Include(s => s.Course)
                .Where(s => s.CourseId == courseId)
                .ToList();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Student? GetStudentById(int id)
        {
            return _context.Students.Include(s => s.Course).FirstOrDefault(s => s.Id == id);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
