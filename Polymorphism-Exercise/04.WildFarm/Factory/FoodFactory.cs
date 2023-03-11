using _04.WildFarm.Factory.Interface;
using _04.WildFarm.Models.Food;
using _04.WildFarm.Models.Food.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Factory;

public class FoodFactory : IFoodFactory
{
    public IFood CreateFood(string type, int quantity)
    {
        switch (type) 
        {
            case "Meat":
                return new Meat(quantity);
            case "Vegetable":
                return new Vegetable(quantity);
            case "Fruit":
                return new Fruit(quantity);
            case "Seeds":
                return new Seeds(quantity);
            default:
                throw new ArgumentException("Invalid type of food");

        }
    }
}
