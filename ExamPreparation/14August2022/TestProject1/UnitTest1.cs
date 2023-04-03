using System;
using PlanetWars;
using System.Linq;
using NUnit.Framework;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

public class Tests_000_101
{
    private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

    [Test]
    public void CreatePlanetWorkProperly()
    {
        var controller = CreateObjectInstance(GetType("Controller"));


        var planetArguments = new object[] { "PlanetOne", 200 };

        var validActualResult = InvokeMethod(controller, "CreatePlanet", planetArguments);
        var validExpectedResult = "Successfully added Planet: PlanetOne";

        Assert.AreEqual(validExpectedResult, validActualResult);


        StringBuilder sb = new StringBuilder();
        sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
        sb.AppendLine("Planet: PlanetOne");
        sb.AppendLine("--Budget: 200 billion QUID");
        sb.AppendLine("--Forces: No units");
        sb.AppendLine("--Combat equipment: No weapons");
        sb.AppendLine("--Military Power: 0");


        var validReport = sb.ToString().TrimEnd();
        var expectedReport = InvokeMethod(controller, "ForcesReport", null);


        Assert.AreEqual(validReport, expectedReport);
    }

    private static object InvokeMethod(object obj, string methodName, object[] parameters)
    {
        try
        {
            var result = obj.GetType()
                .GetMethod(methodName)
                .Invoke(obj, parameters);

            return result;
        }
        catch (TargetInvocationException e)
        {
            return e.InnerException.Message;
        }
    }

    private static object CreateObjectInstance(Type type, params object[] parameters)
    {
        try
        {
            var desiredConstructor = type.GetConstructors()
                .FirstOrDefault(x => x.GetParameters().Any());

            if (desiredConstructor == null)
            {
                return Activator.CreateInstance(type, parameters);
            }

            var instances = new List<object>();

            foreach (var parameterInfo in desiredConstructor.GetParameters())
            {
                var currentInstance = Activator.CreateInstance(GetType(parameterInfo.Name.Substring(1)));

                instances.Add(currentInstance);
            }

            return Activator.CreateInstance(type, instances.ToArray());
        }
        catch (TargetInvocationException e)
        {
            return e.InnerException.Message;
        }
    }

    private static Type GetType(string name)
    {
        var type = ProjectAssembly
            .GetTypes()
            .FirstOrDefault(t => t.Name.Contains(name));

        return type;
    }
}