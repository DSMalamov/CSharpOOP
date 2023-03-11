using _04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals;

public class Owl : Bird
{
    private const double OwlIncrease = 0.25;
    public Owl(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    protected override double WeightIncrease => OwlIncrease;

    protected override IReadOnlyCollection<Type> PreferedFood
        => new HashSet<Type>() { typeof(Meat) };

    public override string ProduceSound()
        => "Hoot Hoot";
}
