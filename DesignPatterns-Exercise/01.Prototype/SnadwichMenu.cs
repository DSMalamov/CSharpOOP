using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Prototype;

public class SandwichMenu
{
    private IDictionary<string, SandwitchPrototype> sandwiches;

	public SandwichMenu()
	{
		sandwiches = new Dictionary<string, SandwitchPrototype>();
	}

	public SandwitchPrototype this[string name]
	{
		get => sandwiches[name];
		set
		{
			sandwiches.Add(name, value);
		}
	}
}
