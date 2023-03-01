using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShoppingSpree.Models;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bag;

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        bag = new List<Product>();
    }

    public decimal Money
    {
        get { return money; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            money = value;
        }
    }


    public string Name
    {
        get => name;

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            name = value;
        }
    }

    public string Add(Product product)
    {
        if (product.Cost > Money)
        {
            Console.WriteLine($"{Name} can't afford {product.Name}");
        }

        bag.Add(product);

        Money -= product.Cost;

        return $"{Name} bought {product.Name}";
    }

    public override string ToString()
    {
        string output = string.Empty;

        if (bag.Any())
        {
            output = string.Join(", ", bag);
        }
        else
        {
            output = "Nothing bought";
        }

        return output;
    }

}




