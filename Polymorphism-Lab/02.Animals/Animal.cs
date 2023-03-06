using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals;

public class Animal
{
    public Animal(string name, string favouriteFood)
    {
        Name = name;
        FavouriteFood = favouriteFood;
    }

    public string Name { get; protected set; }
    public string FavouriteFood { get; protected set; }

    public virtual string ExplainSelf()
    {
        return $"I am {Name} and my fovourite food is {FavouriteFood}";
    }
}
