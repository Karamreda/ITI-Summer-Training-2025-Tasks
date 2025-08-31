using System;
class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();
        History history = new History();

        while (true)
        {
            Console.WriteLine("Select Mode:\n1. Integer Mode\n2. Decimal Mode");
            Console.Write("Enter choice: ");
            string modeChoice = Console.ReadLine();

            if (modeChoice != "1" && modeChoice != "2")
            {
                Console.WriteLine("Invalid mode Please choose 1 or 2.\n");
                continue;
            }
            ///////////////////////////////////////////////

            bool isIntegerMode = modeChoice == "1";

            Console.WriteLine("\nChoose Operation: +  -  *  /  %  ^  √");
            Console.Write("Enter operation: ");
            string operation = Console.ReadLine();

            if (operation != "+" && operation != "-" && operation != "*" &&
                operation != "/" && operation != "%" && operation != "^" && operation != "√")
            {
                Console.WriteLine("Invalid operation Please try again.\n");
                continue;
            }
            /////////////////////////////////////////////////////
            double num1 = 0, num2 = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write("Enter first number: ");
                string input = Console.ReadLine();

                if (isIntegerMode && int.TryParse(input, out int intVal))
                {
                    num1 = intVal;
                    validInput = true;
                }
                else if (!isIntegerMode && double.TryParse(input, out double doubleVal))
                {
                    num1 = doubleVal;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input please try again.");
                }
            }
            //////////////////////////////
            if (operation != "√")
            {
                validInput = false;
                while (!validInput)
                {
                    Console.Write("Enter second number ");
                    string input = Console.ReadLine();

                    if (isIntegerMode && int.TryParse(input, out int intVal))
                    {
                        num2 = intVal;
                        validInput = true;
                    }
                    else if (!isIntegerMode && double.TryParse(input, out double doubleVal))
                    {
                        num2 = doubleVal;
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input please try again.");
                    }
                }
            }
            //////////////////////////////////////////////////////
            try
            {
                object result = null;
                string expression = "";

                switch (operation)
                {
                    case "+":
                        result = isIntegerMode ? calc.Add((int)num1, (int)num2) : calc.Add(num1, num2);
                        expression = $"{num1} + {num2}";
                        break;
                    case "-":
                        result = isIntegerMode ? calc.Subtract((int)num1, (int)num2) : calc.Subtract(num1, num2);
                        expression = $"{num1} - {num2}";
                        break;
                    case "*":
                        result = isIntegerMode ? calc.Multiply((int)num1, (int)num2) : calc.Multiply(num1, num2);
                        expression = $"{num1} * {num2}";
                        break;
                    case "/":
                        result = calc.Divide(num1, num2);
                        expression = $"{num1} / {num2}";
                        break;
                    case "%":
                        result = calc.Modulus((int)num1, (int)num2);
                        expression = $"{num1} % {num2}";
                        break;
                    case "^":
                        result = calc.Power(num1, num2);
                        expression = $"{num1} ^ {num2}";
                        break;
                    case "√":
                        result = calc.SquareRoot(num1);
                        expression = $"√{num1}";
                        break;
                }

                Console.WriteLine($"Result = {result}");

                var historyEntry = new Generic<object> { Expression = expression, Result = result };
                history.Add(historyEntry);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nDo you want to:\n1. Calculate again\n2. View history\n3. Exit");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            if (choice == "2")
            {
                history.Show();
            }
            else if (choice == "3")
            {
                break;
            }

            Console.WriteLine();
        }
    }
}
