using _04.WildFarm.Models.Animals.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Factory.Interface;

public interface IAnimalFactory
{
    IAnimal CreateAnimal(string[] animalArg);
}
