using System;

class Program
{
    public delegate void Operation(double a, double b);
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    static void Add(double a, double b)
    { 
      Console.WriteLine("[+] Result: " + ( a + b ));
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    static void Sub(double a, double b)
    {
        Console.WriteLine("[-] Result: " + ( a - b ));
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    static void Multiply(double a, double b)
    {
      Console.WriteLine("[*] Result: " + ( a * b ));
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    static void Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("[/] Error: Cannot divide by zero");
            return;
        }
        
        Console.WriteLine("[/] Result: " + ( a / b ));
    }
 
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
 
    static void Main()
    {
      
        Console.Write("How many operations do you want to perform? ");
        if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
        {
            Console.WriteLine("Invalid number of operations!");
            return;
        }

        Operation operation = null;

       //////////////////////////////////////////////////////////////////////////////////////////////////////////
       // لوب الكونت بتاع الاوبريشن 


        for (int i = 1; i <= count; i++)
        {
            Console.Write($"Enter operation {i} (+, -, *, /) : ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "+":
                    operation += Add;
                    break;
                case "-":
                    operation += Sub;
                    break;
                case "*":
                    operation += Multiply;
                    break;
                case "/":
                    operation += Divide;
                    break;
                default:
                    Console.WriteLine("Invalid operation try again");
                    i--; 
                    break;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //اليوزر بيدخل رقمين


        Console.Write("\nEnter first number: ");
        if (!double.TryParse(Console.ReadLine(), out double a))
        {
            Console.WriteLine("Invalid number");
            return;
        }

        Console.Write("Enter second number: ");
        if (!double.TryParse(Console.ReadLine(), out double b))
        {
            Console.WriteLine("Invalid number");
            return;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        operation += delegate (double a, double b)
        {
            Console.WriteLine("Log: Executed operation on " + "("+ a  + ", " + b  +")" );
        };

        Console.WriteLine("\nExecuting operations\n");

        operation?.Invoke(a, b);
    }
}

