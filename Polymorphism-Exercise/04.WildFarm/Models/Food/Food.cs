using _04.WildFarm.Models.Food.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Models.Food;

public abstract class Food : IFood
{
	protected Food(int quantity)
	{
		Quantity = quantity;
	}
    public int Quantity { get; private set; }

}
