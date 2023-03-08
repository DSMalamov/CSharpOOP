using _01.Vehicles.Core.Interface;
using _01.Vehicles.Models;
using _01.Vehicles.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles.Core;

internal class Engine : IEngine
{
    private readonly ICollection<IVehicle> vehicles;
    

    public Engine()
    {
        vehicles= new List<IVehicle>();
        
    }

    
    public void Run()
    {
        for (int i = 0; i < 2; i++)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = input[0];
            double fuelQuantity = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);
            try
            {
                if (type == "Car")
                {
                    vehicles.Add(new Car(fuelQuantity, fuelConsumption));
                }
                else if (type == "Truck")
                {
                    vehicles.Add(new Truck(fuelQuantity, fuelConsumption));
                }
                else
                {
                    throw new ArgumentException("Invalid vehicle type");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }

        int cycles = int.Parse(Console.ReadLine());

        for (int i = 0; i < cycles; i++)
        {
            try
            {
                Process();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            

        }

        foreach (var item in vehicles)
        {
            Console.WriteLine(item.ToString());
        }


    }

    private void Process()
    {
        string[] command = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string cmd = command[0];
        string type = command[1];
        double distance = double.Parse(command[2]);

        IVehicle vehicle = vehicles.FirstOrDefault(n => n.GetType().Name == type);

        if (cmd == "Drive")
        {
            Console.WriteLine(vehicle.Drive(distance));
        }
        else if (cmd == "Refuel")
        {
            vehicle.Refuel(distance);
        }
        else if (vehicle == null)
        {
            throw new ArgumentException("Invalid vehicle type");
        }
    }
}
