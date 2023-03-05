using _09.ExplicitInterfaces.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.ExplicitInterfaces.Models
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Country { get; private set; }

        string IPerson.GetName()
        {
            return Name;
        }

        string IResident.GetName() => $"{"Mr/Ms/Mrs"} {Name}";
    }
}
