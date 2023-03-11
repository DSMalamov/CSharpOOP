using _04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals;

public class Dog : Mammal
{
    private const double DogIncrease = 0.4;
    public Dog(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    protected override double WeightIncrease => DogIncrease;

    protected override IReadOnlyCollection<Type> PreferedFood 
        => new HashSet<Type>() { typeof(Meat)};

    public override string ProduceSound()
        => "Woof!";

    public override string ToString()
    {
        return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
