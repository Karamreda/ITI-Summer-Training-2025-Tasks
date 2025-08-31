using System;

class Program
{
    static void Main()
    {

        double num1 = GetNumber("Enter first number: ");
        double num2 = GetNumber("Enter second number: ");

        Console.Write("Enter operation (+, -, *, /): ");
        string op = Console.ReadLine();

        while (op != "+" && op != "-" && op != "*" && op != "/")
        {
            Console.Write("Invalid operation Enter (+, -, *, /): ");
            op = Console.ReadLine();
        }

        double result = 0;
        if (op == "+") result = num1 + num2;
        else if (op == "-") result = num1 - num2;
        else if (op == "*") result = num1 * num2;
        else if (op == "/")
        {
            if (num2 == 0)
            {
                Console.WriteLine("Cannot divide by zero!");
                return;
            }
            result = num1 / num2;
        }

        Console.WriteLine("Result = " + result);

        Console.WriteLine("\nAge Group ");
        int age = (int)GetNumber("Enter your age: ");

        while (age < 0)
        {
            Console.Write("Age must be positive! Enter again: ");
            age = (int)GetNumber("");
        }

        if (age <= 12)
            Console.WriteLine("Category: Child");
        else if (age <= 19)
            Console.WriteLine("Category: Teen");
        else if (age <= 59)
            Console.WriteLine("Category: Adult");
        else
            Console.WriteLine("Category: Senior");
    }

    static double GetNumber(string test)
    {
        double num;
        Console.Write(test);
        while (!double.TryParse(Console.ReadLine(), out num))
        {
            Console.Write("Invalid! Enter a number: ");
        }
        return num;
    }
}
