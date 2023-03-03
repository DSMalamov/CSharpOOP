using _04.BorderControl.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl.Models;

public class Citizens : IIdentifiable
{
    public Citizens(string name, int age, string id)
    {
        Name = name;
        Age = age;
        Id = id;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Id { get; private set; }
}
