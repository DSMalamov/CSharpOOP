using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite.Models.Interface
{
    public interface IRepair
    {
        string Name { get; }
        int HoursWorked { get;  }
    }
}
