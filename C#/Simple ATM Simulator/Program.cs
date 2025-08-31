using System.Transactions;

namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int balance = 1000;
            bool check = true;

            while (check)
            {
                Console.WriteLine("\nWelcome to Simple ATM");
                Console.WriteLine($"Your current balance:");
                Console.WriteLine("\n1.View Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Exit");

                Console.WriteLine("\nEnter your choice:");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"\nYour Balance:${balance}");
                        break;

                    case "2":
                        Console.WriteLine("Enter amount to deposit: ");
                        int deposit = int.Parse(Console.ReadLine());
                        balance += deposit;
                        Console.WriteLine($"\nDeposit successful. ");
                        break;

                    case "3":
                        Console.WriteLine("Enter amount to Withdraw: ");
                        int Withdraw = int.Parse(Console.ReadLine());
                        if (Withdraw <= balance)
                        {
                            balance -= Withdraw;
                            Console.WriteLine($"\nwithdraw succesful.");
                        }
                        else
                        {
                            Console.WriteLine("\nInsufficient balance! Withdrawl canceled. ");
                        }
                        break;

                    case "4":
                        Console.WriteLine("\nThank you for using simple ATM. Goodbye! ");
                        check = false;
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice! please enter 1-4. ");
                        break;




                }


            }
        }
    }
}