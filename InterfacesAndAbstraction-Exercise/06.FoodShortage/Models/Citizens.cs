using _06.FoodShortage.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FoodShortage.Models.Interface;

public class Citizens : IBuyer
{
    public Citizens(string name, int age, string id, string birhDate)
    {
        Name = name;
        Age = age;
        Id = id;
        BirhDate = birhDate;
        Food = 0;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Id { get; private set; }
    public string BirhDate { get; private set; }
    public int Food { get; private set; }

    public void BuyFood()
    {
        Food += 10;
    }
}
