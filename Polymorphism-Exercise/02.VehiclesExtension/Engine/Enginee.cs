using _01.Vehicles.Models.Interface;
using _02.VehiclesExtension.Engine.Interface;
using _02.VehiclesExtension.Factory.Interface;
using _02.VehiclesExtension.IO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension.Engine;

public class Enginee : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IVehicleFactory factory;
    private readonly ICollection<IVehicle> vehicles;

    public Enginee(IReader reader, IWriter writer, IVehicleFactory factory)
    {
        this.reader = reader;
        this.writer = writer;
        this.factory = factory;

        this.vehicles = new List<IVehicle>();
    }

    public void Run()
    {
        vehicles.Add(CreateVehicle()); //Add car
        vehicles.Add(CreateVehicle()); //Add truck
        vehicles.Add(CreateVehicle()); //Add bus

        int cycles = int.Parse(reader.ReadLine());

        for (int i = 0; i < cycles; i++)
        {
            try
            {
                string[] commadArg = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commadArg[0];
                string type = commadArg[1];

                ProcessCommand(command, type, double.Parse(commadArg[2]));
            }
            catch (ArgumentException ex)
            {
                writer.WriteLine(ex.Message);
            }
            catch(Exception)
            {
                throw;
            }
           
        }

        foreach (var item in vehicles)
        {
            writer.WriteLine(item.ToString());
        }
    }

    private void ProcessCommand(string command, string type, double amount)
    {
        IVehicle vehicle = vehicles.FirstOrDefault(n => n.GetType().Name == type);
        bool isEmpty = false;
        if (vehicle == null)
        {
            throw new ArgumentException("Invalid vehicle type.");
        }
        if (command == "Drive")
        {
            writer.WriteLine(vehicle.Drive(amount, isEmpty));
        }
        else if (command == "Refuel")
        {
            vehicle.Refuel(amount);
        }
        else if (command == "DriveEmpty")
        {
            isEmpty = true;
            writer.WriteLine(vehicle.Drive(amount, isEmpty));
        }
    }

    private IVehicle CreateVehicle()
    {
        string[] vehicleArg = reader.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        return factory.CreateVehicle(vehicleArg);
    }
}
