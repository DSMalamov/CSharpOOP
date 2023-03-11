using _04.WildFarm.Models.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals;

public class Hen : Bird
{
    private const double HenIncrease = 0.35;
    public Hen(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    protected override double WeightIncrease => HenIncrease;

    protected override IReadOnlyCollection<Type> PreferedFood
        => new HashSet<Type>() { typeof(Meat), typeof(Vegetable), typeof(Fruit), typeof(Seeds) };

    public override string ProduceSound()
        => "Cluck";


}
