using _04.WildFarm.Models.Animals.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals;

public abstract class Mammal : Animal, IMammal
{
    protected Mammal(string name, double weight, string livingRegion) 
        : base(name, weight)
    {
        LivingRegion = livingRegion;
    }

    public string LivingRegion { get; private set; }

    
}
