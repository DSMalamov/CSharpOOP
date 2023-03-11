using _02.VehiclesExtension.Engine;
using _02.VehiclesExtension.Engine.Interface;
using _02.VehiclesExtension.Factory;
using _02.VehiclesExtension.Factory.Interface;
using _02.VehiclesExtension.IO;
using _02.VehiclesExtension.IO.Interface;

namespace _02.VehiclesExtension;

public class StartUp
{
    static void Main(string[] args)
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IVehicleFactory vehicle = new VehicleFactory();

        IEngine engine = new Enginee(reader, writer, vehicle);

        engine.Run();
    }
}