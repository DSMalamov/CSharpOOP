using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.ExplicitInterfaces.Models.Interface
{
    public interface IPerson
    {
        public string Name { get; }
        public int Age { get; }

        string GetName();
    }
}
