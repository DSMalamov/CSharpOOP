using _04.WildFarm.Models.Food.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Factory.Interface;

public interface IFoodFactory
{
    IFood CreateFood(string type, int quantity);
}
