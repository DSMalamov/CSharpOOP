using _04.WildFarm.Models.Animals.Interface;
using _04.WildFarm.Models.Food.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals;

public abstract class Animal : IAnimal
{
    protected Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
        
    }

    public string Name {get; private set;}

    public double Weight { get; private set; }

    public int FoodEaten { get; private set; }
    protected abstract double WeightIncrease { get; }
    protected abstract IReadOnlyCollection<Type> PreferedFood { get; }

    public abstract string ProduceSound();

    public void Eat(IFood food)
    {
        if (!PreferedFood.Any(pf => pf.Name == food.GetType().Name))
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        Weight += food.Quantity * WeightIncrease;

        FoodEaten += food.Quantity;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{Name}, ";
    }
}
