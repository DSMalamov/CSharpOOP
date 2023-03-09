using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding.Models;

public class Rogue : BaseHero
{
    private const int DefaultPower = 80;
    public Rogue(string name) 
        : base(name, DefaultPower)
    {
    }

    public override string CastAbility()
    {
        return $"{this.GetType().Name} - {Name} hit for {Power} damage";
    }
}
