using _04.WildFarm.Core.Interface;
using _04.WildFarm.Factory.Interface;
using _04.WildFarm.IO.Interface;
using _04.WildFarm.Models.Animals.Interface;
using _04.WildFarm.Models.Food.Interface;

namespace _04.WildFarm.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IFoodFactory foodFactory;
    private readonly IAnimalFactory animalFatory;
    private readonly ICollection<IAnimal> animals;


    public Engine(IReader reader, IWriter writer, IFoodFactory foodFactory, IAnimalFactory animalFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.foodFactory = foodFactory;
        this.animalFatory = animalFactory;

        animals = new List<IAnimal>();

    }

    public void Run()
    {
        string command;

        while ((command = Console.ReadLine()) != "End")
        {

            IAnimal animal = null;

            try
            {
                animal = CreateAnimal(command);

                IFood food = CreateFood();

                writer.WriteLine(animal.ProduceSound());

                animal.Eat(food);

            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }

            animals.Add(animal);
 
        }

        foreach (var item in animals)
        {
            writer.WriteLine(item.ToString());

        }
    }

    private IFood CreateFood()
    {
        string[] foodArg = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        IFood food = foodFactory.CreateFood(foodArg[0], int.Parse(foodArg[1]));

        return food;
    }

    private IAnimal CreateAnimal(string command)
    {
        string[] animalArgs = command
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        IAnimal animal = animalFatory.CreateAnimal(animalArgs);

        return animal;
    }
}
