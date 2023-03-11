using _04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals;

public class Cat : Feline
{
    private const double CatIncrease = 0.3;

    public Cat(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    {
    }

    protected override double WeightIncrease => CatIncrease;

    protected override IReadOnlyCollection<Type> PreferedFood 
        => new HashSet<Type>() { typeof(Vegetable), typeof(Meat)};

    public override string ProduceSound()
        => "Meow";
    
}
