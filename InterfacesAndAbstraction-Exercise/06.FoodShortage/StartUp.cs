
using _06.FoodShortage.Models;
using _06.FoodShortage.Models.Interface;

List<IBuyer> buyers = new();

int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    string input = Console.ReadLine();
    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (tokens.Length == 4)
    {
        IBuyer citizen = new Citizens(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
        buyers.Add(citizen);
    }
    else
    {
        IBuyer rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
        buyers.Add(rebel);
    }
}

string command;

while ((command = Console.ReadLine()) != "End")
{

    buyers.FirstOrDefault(buyer => buyer.Name == command)?.BuyFood();
}

Console.WriteLine(buyers.Sum(b => b.Food));


