using _04.BorderControl.Models;
using _04.BorderControl.Models.Interface;

namespace _04.BorderControl;

public class StartUp
{
    static void Main(string[] args)
    {
        List<IIdentifiable> collection = new();

        string command;

        while ((command = Console.ReadLine()) != "End")
        {
            string[] cmdArg = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (cmdArg.Length == 3)
            {
                IIdentifiable citizen = new Citizens(cmdArg[0], int.Parse(cmdArg[1]), cmdArg[2]);
                collection.Add(citizen);
            }
            else if (cmdArg.Length == 2)
            {
                IIdentifiable robot = new Robot(cmdArg[0], cmdArg[1]);
                collection.Add(robot);
            }
        }

        string controll = Console.ReadLine();

        foreach (var item in collection)
        {
            if (item.Id.EndsWith(controll))
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}