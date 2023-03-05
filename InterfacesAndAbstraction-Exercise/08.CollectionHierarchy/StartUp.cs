
using _08.CollectionHierarchy.Models;
using _08.CollectionHierarchy.Models.Interface;

string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
IAddCollection collection1= new AddCollection();
IAddRemoveCollection collection2= new AddRemoveCollection();
IMyList collection3= new MyList();

Dictionary<string, List<int>> addCol = new Dictionary<string, List<int>>() 
{
    {"AddCollection", new List<int>() },
    {"AddRemoveCollection", new List<int>()},
    {"MyList", new List<int>()}
};

Dictionary<string, List<string>> removeCol = new Dictionary<string, List<string>>()
{
    {"AddCollection", new List<string>() },
    {"AddRemoveCollection", new List<string>()},
    {"MyList", new List<string>()}
};

foreach (var item in input)
{
    addCol["AddCollection"].Add(collection1.Add(item));
    addCol["AddRemoveCollection"].Add(collection2.Add(item));
    addCol["MyList"].Add(collection3.Add(item));
}

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    removeCol["AddRemoveCollection"].Add(collection2.Remove());
    removeCol["MyList"].Add(collection3.Remove());
}

Console.WriteLine(string.Join(" ", addCol["AddCollection"]));
Console.WriteLine(string.Join(" ", addCol["AddRemoveCollection"]));
Console.WriteLine(string.Join(" ", addCol["MyList"]));

Console.WriteLine(string.Join(" ", removeCol["AddRemoveCollection"]));
Console.WriteLine(string.Join(" ", removeCol["MyList"]));

