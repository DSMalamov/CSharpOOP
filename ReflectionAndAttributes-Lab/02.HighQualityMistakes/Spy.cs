﻿
using System.Reflection;
using System.Text;

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

    public string AnalyzeAccessModifiers(string className)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] classFields = classType.GetFields(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.Static);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classPrivateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (var item in classFields)
        {
            sb.AppendLine($"{item.Name} must be private!");
        }
        foreach (var item in classPrivateMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{item.Name} have to be public!");
        }
        foreach (var item in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{item.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }
}
