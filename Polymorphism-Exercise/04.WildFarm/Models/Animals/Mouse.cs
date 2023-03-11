using _04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals;

public class Mouse : Mammal
{
    private const double MouseIncrease = 0.1;
    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    protected override double WeightIncrease => MouseIncrease;

    protected override IReadOnlyCollection<Type> PreferedFood
        => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit) };

    public override string ProduceSound()
        => "Squeak";

    public override string ToString()
    {
        return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
