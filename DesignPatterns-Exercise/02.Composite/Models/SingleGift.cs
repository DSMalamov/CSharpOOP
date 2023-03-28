using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Composite.Models;

public class SingleGift : GiftBase
{
    public SingleGift(string name, int price) 
        : base(name, price)
    {

    }

    public override int CalculateTotalPrice()
    {
        Console.WriteLine($"{Name} with price {Price}");

        return Price;
    }
}
