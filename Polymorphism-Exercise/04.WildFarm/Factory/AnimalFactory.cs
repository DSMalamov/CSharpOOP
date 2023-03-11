using _04.WildFarm.Factory.Interface;
using _04.WildFarm.Models.Animals;
using _04.WildFarm.Models.Animals.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Factory;

public class AnimalFactory : IAnimalFactory
{
    public IAnimal CreateAnimal(string[] animalArg)
    {
        string type = animalArg[0];
        string name = animalArg[1];
        double weight = double.Parse(animalArg[2]);

        switch (type)
        {
            case "Cat":
                return new Cat(name, weight, animalArg[3], animalArg[4]);
            case "Owl":
                return new Owl(name, weight, double.Parse(animalArg[3]));
            case "Hen":
                return new Hen(name, weight, double.Parse(animalArg[3]));
            case "Mouse":
                return new Mouse(name, weight, animalArg[3]);
            case "Dog":
                return new Dog(name, weight, animalArg[3]);
            case "Tiger":
                return new Tiger(name, weight, animalArg[3], animalArg[4]);
            default:
                throw new ArgumentException("Invalid animal type");
        }
    }
}
