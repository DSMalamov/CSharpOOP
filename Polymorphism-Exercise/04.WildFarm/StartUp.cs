using _04.WildFarm.Core;
using _04.WildFarm.Core.Interface;
using _04.WildFarm.Factory;
using _04.WildFarm.Factory.Interface;
using _04.WildFarm.IO;
using _04.WildFarm.IO.Interface;

namespace _04.WildFarm;

public class StartUp
{
    static void Main(string[] args)
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IAnimalFactory animalFactory = new AnimalFactory();
        IFoodFactory foodFactory = new FoodFactory();
        
        IEngine engine = new Engine(reader, writer, foodFactory, animalFactory);

        engine.Run();
    }
}