using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Prototype
{
    public class Sandwich : SandwitchPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string vegetable;

        public Sandwich(string bread, string meat, string cheese, string vegetable)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.vegetable = vegetable;
        }

        public override SandwitchPrototype Clone()
        {
            Console.WriteLine($"Cloning sandwich with ingredients: {GetIngredientList()}");

            return MemberwiseClone() as SandwitchPrototype;
        }

        private string GetIngredientList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.vegetable}";
        }
    }
}
