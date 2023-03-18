using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Atributes;

namespace ValidationAttributes;

public class Person
{
    private const int minAge = 12;
    private const int maxAge = 90;
    public Person(string fullName, int age)
    {
        FullName = fullName;
        Age = age;
    }

    [MyRequired]
    public string FullName { get; private set; }

    [MyRange(minAge,maxAge)]
    public int Age { get; private set; }
}
