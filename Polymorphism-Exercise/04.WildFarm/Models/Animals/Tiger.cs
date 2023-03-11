using _04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals;

public class Tiger : Feline
{
    private const double DogIncrease = 1;
    public Tiger(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    protected override double WeightIncrease => DogIncrease;

    protected override IReadOnlyCollection<Type> PreferedFood
        => new HashSet<Type>() { typeof(Meat) };

    public override string ProduceSound()
        => "ROAR!!!";
}
