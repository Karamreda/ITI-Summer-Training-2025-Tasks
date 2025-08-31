using EFCoreConsoleApp.Data;


class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();

      
        SeedData(context);

        var repo = new StudentsRepository(context);

        Console.WriteLine("All Students with their Courses:");
        var students = repo.GetAllStudentsWithCourse();
        foreach (var s in students)
        {
            Console.WriteLine($"{s.FullName} - {s.Course.CourseName}");
        }

        Console.WriteLine("\nStudents in CourseId = 1:");
        var courseStudents = repo.GetStudentsByCourse(1);
        foreach (var s in courseStudents)
        {
            Console.WriteLine($"{s.FullName} - {s.Course.CourseName}");
        }

        Console.ReadKey();
    }

    static void SeedData(AppDbContext context)
    {
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
        }

        if (!context.Students.Any())
        {
            var students = new List<Student>
            {
                new Student { FullName="Ahmed Ali", Age=20, Email="ahmed@test.com", IsActive=true, CourseId=1 },
                new Student { FullName="Sara Mohamed", Age=22, Email="sara@test.com", IsActive=true, CourseId=2 },
                new Student { FullName="Khaled Ibrahim", Age=21, Email="khaled@test.com", IsActive=true, CourseId=3 },
                new Student { FullName="Mona Adel", Age=19, Email="mona@test.com", IsActive=true, CourseId=1 },
                new Student { FullName="Omar Hussein", Age=23, Email="omar@test.com", IsActive=true, CourseId=2 },
                new Student { FullName="Huda Samir", Age=20, Email="huda@test.com", IsActive=true, CourseId=3 },
                new Student { FullName="Youssef Amr", Age=21, Email="youssef@test.com", IsActive=true, CourseId=1 },
                new Student { FullName="Layla Hassan", Age=22, Email="layla@test.com", IsActive=true, CourseId=2 },
                new Student { FullName="Mostafa Reda", Age=20, Email="mostafa@test.com", IsActive=true, CourseId=3 },
                new Student { FullName="Nour Adel", Age=19, Email="nour@test.com", IsActive=true, CourseId=1 }
            };
            context.Students.AddRange(students);
            context.SaveChanges();
        }
    }
}
