using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Product> inventory = new List<Product>();

        Console.Write("How many products to add? ");
        int count;
        while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
        {
            Console.Write("Invalid. Enter a positive number: ");
        }

        for (int i = 1; i <= count; i++)
        {
            Console.WriteLine($"\nProduct {i}:");

           
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

           
            int qty;
            Console.Write("Enter quantity in stock: ");
            while (!int.TryParse(Console.ReadLine(), out qty) || qty < 0)
            {
                Console.Write("Invalid. Enter a positive quantity: ");
            }

            double price;
            Console.Write("Enter unit price: ");
            while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
            {
                Console.Write(" Invalid. Enter a valid price: ");
            }

            inventory.Add(new Product(name, qty, price));
        }

        
        Console.WriteLine("\nInventory List:");
        foreach (var item in inventory)
        {
            Console.WriteLine($" {item.Name} | Qty: {item.Quantity} | Price: {item.Price} EGP");
        }

       
        double totalValue = 0;
        foreach (var item in inventory)
        {
            totalValue += item.Quantity * item.Price;
        }
        Console.WriteLine($"\n Total Inventory Value: {totalValue:N0} EGP");

        
        Console.Write("\nSearch for product: ");
        string search = Console.ReadLine();

        Product found = inventory.Find(p => p.Name.Equals(search, StringComparison.OrdinalIgnoreCase));
        if (found != null)
        {
            Console.WriteLine($" {found.Name} found! Quantity: {found.Quantity}, Price: {found.Price}");
        }
        else
        {
            Console.WriteLine(" Product not found.");
        }
    }
}
