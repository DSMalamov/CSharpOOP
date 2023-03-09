using _03.Raiding.Factory.Interface;
using _03.Raiding.Models;
using _03.Raiding.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding.Factory;

public class HeroFactory : IFactory
{
    public IBaseHero Create (string heroType, string name)
    {

        if (heroType == "Druid") 
        {
            return new Druid(name);
        }
        else if (heroType == "Paladin")
        {
            return new Paladin(name);
        }
        else if (heroType == "Rogue")
        {
            return new Rogue(name);
        }
        else if (heroType == "Warrior")
        {
            return new Warrior(name);
        }
        else
        {
            throw new ArgumentException("Invalid hero!");
        }
    }
}
