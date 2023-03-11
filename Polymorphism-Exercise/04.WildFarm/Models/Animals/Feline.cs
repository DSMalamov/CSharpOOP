using _04.WildFarm.Models.Animals.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Feline : Mammal, IFeline
    {
        protected Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"{Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
