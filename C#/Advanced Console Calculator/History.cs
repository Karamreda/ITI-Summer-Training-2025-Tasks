using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class History
{
    private List<object> history = new List<object>();

    public void Add(object entry)
    {
        history.Add(entry);
    }

    public void Show()
    {
        if (history.Count == 0)
        {
            Console.WriteLine("No history available.");
            return;
        }

        Console.WriteLine("\nCalculation History:");
        foreach (var item in history)
        {
            Console.WriteLine(item);
        }
    }
}
