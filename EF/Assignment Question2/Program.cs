using EFCoreConsoleApp.Data;
using EFCoreConsoleApp.Models;
using EFCoreConsoleApp.Repositories;

class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();

        context.Database.EnsureDeleted(); 
        context.Database.EnsureCreated(); 
       

        if (!context.Courses.Any())
        {
            var courses = new List<Course>
            {
                new Course { CourseName = "Mathematics" },
                new Course { CourseName = "Computer Science" },
                new Course { CourseName = "Biology" }
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            var students = new List<Student>
            {
                new Student { FullName="Karam Reda", Age=20, Email="karam@gmail.com", IsActive=true, CourseId=1 },
                new Student { FullName="Mona Hassan", Age=22, Email="mona@gmail.com", IsActive=true, CourseId=2 },
                new Student { FullName="Omar Ali", Age=21, Email="omar@gmail.com", IsActive=false, CourseId=3 },
                new Student { FullName="Sara Youssef", Age=19, Email="sara@gmail.com", IsActive=true, CourseId=1 },
                new Student { FullName="Karim Mohamed", Age=23, Email="karim@gmail.com", IsActive=true, CourseId=2 },
                new Student { FullName="Huda Nabil", Age=20, Email="huda@gmail.com", IsActive=true, CourseId=3 },
                new Student { FullName="Mostafa Ibrahim", Age=24, Email="mostafa@gmail.com", IsActive=false, CourseId=2 },
                new Student { FullName="Aya Samir", Age=18, Email="aya@gmail.com", IsActive=true, CourseId=1 },
                new Student { FullName="Youssef Adel", Age=21, Email="youssef@gmail.com", IsActive=true, CourseId=2 },
                new Student { FullName="Nour Ahmed", Age=20, Email="nour@gmail.com", IsActive=true, CourseId=3 }
            };

            context.Students.AddRange(students);
            context.SaveChanges();
        }

        var repo = new StudentsRepository(context);

        Console.WriteLine("📌 All Students with their Courses:");
        foreach (var student in repo.GetAllStudentsWithCourse())
        {
            Console.WriteLine($"{student.FullName} - {student.Course.CourseName}");
        }

        Console.WriteLine("\n📌 Students in Course 2 (Computer Science):");
        foreach (var student in repo.GetStudentsByCourse(2))
        {
            Console.WriteLine($"{student.FullName} - {student.Course.CourseName}");
        }
    }
}
