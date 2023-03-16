using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer;

public class Spy
{
    public string StealFieldInfo(string name, params string[] fields)
    {
        Type classType = Type.GetType(name);

        FieldInfo[] classFields = classType.GetFields(
            BindingFlags.Instance |
            BindingFlags.NonPublic |
            BindingFlags.Public |
            BindingFlags.Static
            );

        StringBuilder sb = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { } );

        sb.AppendLine($"Class under investigation: {classType}");

        foreach (var item in classFields.Where(f => fields.Contains(f.Name)))
        {
            sb.AppendLine($"{item.Name} = {item.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}
