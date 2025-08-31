using System;

abstract class Shape
{
    public abstract double CalculateArea();

    public virtual void Display()
    {
        Console.WriteLine("shape area");
    }
}
///////////////////////////////////////////////////////////////////////////////

class Circle : Shape
{
    double r;
    public Circle(double r)
    {
        this.r = r;
    }

    public override double CalculateArea()
    {
        return Math.PI * r * r;
    }

    public override void Display()
    {
        Console.WriteLine($"Area of Circle = {CalculateArea()}");
    }
}
///////////////////////////////////////////////////////////////////////////////

class Rectangle : Shape
{
    double w, h;

    public Rectangle(double w, double h)
    {
        this.w = w;
        this.h = h;
    }

    public Rectangle(double side) : this(side, side)
    {
    }

    public override double CalculateArea()
    {
        return w * h;
    }

    public override void Display()
    {
        Console.WriteLine($"Area of Rectangle = {CalculateArea()}");
    }
}
///////////////////////////////////////////////////////////////////////////////

class Triangle : Shape
{
    double b, h;

    public Triangle(double b, double h)
    {
        this.b = b;
        this.h = h;
    }

    public override double CalculateArea()
    {
        return 0.5 * b * h;
    }

    public override void Display()
    {
        Console.WriteLine($"Area of Triangle = {CalculateArea()}");
    }
}
///////////////////////////////////////////////////////////////////////////////

class Program
{
    static void Main()
    {
        Console.WriteLine("══════════════════════════════");
        Console.WriteLine("   Welcome to Shape Calculator");
        Console.WriteLine("══════════════════════════════");
        Console.WriteLine("Please choose a shape:");
        Console.WriteLine("1 - Circle");
        Console.WriteLine("2 - Rectangle");
        Console.WriteLine("3 - Triangle");
        Console.Write("Your choice: ");

        int ch;
        while (!int.TryParse(Console.ReadLine(), out ch) || ch < 1 || ch > 3)
        {
            Console.Write("Invalid choice, please try again: ");
        }

        Shape s = null;

        if (ch == 1)
        {
            Console.Write("Enter the radius of the circle: ");
            double r = GetPos();
            s = new Circle(r);
        }
        else if (ch == 2)
        {
            Console.Write("Enter the width of the rectangle: ");
            double w = GetPos();
            Console.Write("Enter the height of the rectangle: ");
            double h = GetPos();
            s = new Rectangle(w, h);
        }
        else
        {
            Console.Write("Enter the base of the triangle: ");
            double b = GetPos();
            Console.Write("Enter the height of the triangle: ");
            double h = GetPos();
            s = new Triangle(b, h);
        }
        //////////////////////////////////////////////////////////////////////////////////////
        Console.WriteLine("──────────────────────────────");
        s.Display();
        Console.WriteLine("──────────────────────────────");
    }



    static double GetPos()
    {
        double x;
        while (!double.TryParse(Console.ReadLine(), out x) || x <= 0)
        {
            Console.Write("Invalid input. Please enter a positive number: ");
        }
        return x;
    }
}
