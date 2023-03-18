using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProblem;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
            {
                var atributes = method.GetCustomAttributes(false);

                foreach (AuthorAttribute attr in atributes)
                {
                    Console.WriteLine($"{0} is written by {1}", method.Name, attr.Name);
                }
            }
        }

    }
}
