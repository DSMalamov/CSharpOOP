using _04.BorderControl.Models;
using _04.BorderControl.Models.Interface;
using _05.BirthdayCelebrations.Models;
using _05.BirthdayCelebrations.Models.Interface;

namespace _04.BorderControl;

public class StartUp
{
    static void Main(string[] args)
    {
        List<IBirthable> collection = new();

        string command;

        while ((command = Console.ReadLine()) != "End")
        {
            string[] cmdArg = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (cmdArg[0] == "Citizen")
            {
                IBirthable citizen = new Citizens(cmdArg[1], int.Parse(cmdArg[2]), cmdArg[3], cmdArg[4]);
                collection.Add(citizen);
            }
            else if (cmdArg[0] == "Pet")
            {
                IBirthable pet = new Pet(cmdArg[1], cmdArg[2]);
                collection.Add(pet);
            }
        }

        string controll = Console.ReadLine();

        foreach (var item in collection)
        {
            if (item.BirthDate.EndsWith(controll))
            {
                Console.WriteLine(item.BirthDate);
            }
        }
    }
}