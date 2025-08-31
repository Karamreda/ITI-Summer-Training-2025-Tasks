using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Manager
{
    public List<Product> Inventory { get; private set; } = new List<Product>();

    public void AddProduct(Product product)
    {
        Inventory.Add(product);
    }

    public void DisplayInventory()
    {
        Console.WriteLine("\nInventory List:");
        foreach (var item in Inventory)
        {
            Console.WriteLine($"{item.Name} | Qty: {item.Quantity} | Price: {item.Price} EGP");
        }
    }

    public double GetTotalValue()
    {
        double total = 0;
        foreach (var item in Inventory)
        {
            total += item.Quantity * item.Price;
        }
        return total;
    }

    public Product Search(string name)
    {
        return Inventory.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}

