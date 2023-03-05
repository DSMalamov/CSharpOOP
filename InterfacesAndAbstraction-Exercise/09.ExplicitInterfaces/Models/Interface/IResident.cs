using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.ExplicitInterfaces.Models.Interface
{
    public interface IResident
    {
        public string Name { get;}
        public string Country { get;}

        string GetName();
        

    }
}
