using _09.ExplicitInterfaces.Core.Interface;
using _09.ExplicitInterfaces.Models;
using _09.ExplicitInterfaces.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.ExplicitInterfaces.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArg = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = cmdArg[0];
                string country = cmdArg[1];
                int age = int.Parse(cmdArg[2]);
                IPerson person = new Citizen(name, age, country);
                IResident resident = new Citizen(name, age, country);
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }

        }
    }
}
