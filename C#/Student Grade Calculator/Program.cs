using System;

class Student
{
    public string Name { get; set; }
    public int ID { get; set; }

    private double averageGrade;
    public double AverageGrade
    {
        get { return averageGrade; }
        private set
        {
            if (value >= 0 && value <= 100)
                averageGrade = value;
            else
                averageGrade = 0;
        }
    }

    private static int count = 0;

    public Student(string name, int id)
    {
        Name = name;
        ID = id;
        count++;
    }

    public void CalculateAverage(double g1, double g2)
    {
        AverageGrade = (CheckGrade(g1) + CheckGrade(g2)) / 2;
    }

    public void CalculateAverage(double g1, double g2, double g3)
    {
        AverageGrade = (CheckGrade(g1) + CheckGrade(g2) + CheckGrade(g3)) / 3;
    }

    private double CheckGrade(double g)
    {
        if (g >= 0 && g <= 100)
            return g;
        else
        {
            Console.WriteLine("Invalid grade: Please Enter number between 0 and 100");
        }
        return 0;
    }

    public static int GetCount()
    {
        return count;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Student Record System");

        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Student ID: ");
        int id = int.Parse(Console.ReadLine());

        Student s = new Student(name, id);

        Console.Write("How Many Subjects? (2 or 3): ");
        int n = int.Parse(Console.ReadLine());

        if (n == 2)
        {
            Console.Write("Enter Your Grade for subject 1: ");
            double g1 = double.Parse(Console.ReadLine());

            Console.Write("Enter Your Grade for subject 2: ");
            double g2 = double.Parse(Console.ReadLine());

            s.CalculateAverage(g1, g2);
        }
        else if (n == 3)
        {
            Console.Write("Enter Your Grade for subject 1: ");
            double g1 = double.Parse(Console.ReadLine());

            Console.Write("Enter Your Grade for subject 2: ");
            double g2 = double.Parse(Console.ReadLine());

            Console.Write("Enter Your Grade for subject 3: ");
            double g3 = double.Parse(Console.ReadLine());

            s.CalculateAverage(g1, g2, g3);
        }

        Console.WriteLine("\nStudent Name: " + s.Name);
        Console.WriteLine("ID: " + s.ID);
        Console.WriteLine("Average Grade: " + s.AverageGrade);
        Console.WriteLine("Total Students: " + Student.GetCount());
    }
}

