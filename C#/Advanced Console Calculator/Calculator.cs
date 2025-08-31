using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Calculator
{
    public int Add(int a, int b) => a + b;
    public double Add(double a, double b) => a + b;

    public int Subtract(int a, int b) => a - b;
    public double Subtract(double a, double b) => a - b;

    public int Multiply(int a, int b) => a * b;
    public double Multiply(double a, double b) => a * b;

    public double Divide(double a, double b)
    {
        if (b == 0) throw new DivideByZeroException("Invalid Cannot divide by zero!");
        return a / b;
    }

    public int Modulus(int a, int b)
    {
        if (b == 0) throw new DivideByZeroException("Invalid Cannot divide by zero");
        return a % b;
    }

    public double Power(double a, double b) => Math.Pow(a, b);

    public double SquareRoot(double a)
    {
        if (a < 0) throw new ArgumentException("Invalid Cannot take square root of a negative number");
        return Math.Sqrt(a);
    }
}
