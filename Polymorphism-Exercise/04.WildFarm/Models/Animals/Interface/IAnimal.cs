using _04.WildFarm.Models.Food.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Animals.Interface;

public interface IAnimal
{
    string Name { get; }
    double Weight { get; }
    int FoodEaten { get; }

    string ProduceSound();

    void Eat(IFood food);

}
