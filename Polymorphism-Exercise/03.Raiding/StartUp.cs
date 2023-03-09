using _03.Raiding.Core;
using _03.Raiding.Factory;
using _03.Raiding.Factory.Interface;

namespace _03.Raiding;

public class StartUp
{
    static void Main(string[] args)
    {
        IFactory factory = new HeroFactory();
        Engine engine= new Engine(factory);
        engine.Run();
        
    }
}