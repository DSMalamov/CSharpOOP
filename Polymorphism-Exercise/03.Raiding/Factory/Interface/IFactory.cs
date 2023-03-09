using _03.Raiding.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding.Factory.Interface;

public interface IFactory
{
    IBaseHero Create(string type, string name);
}
