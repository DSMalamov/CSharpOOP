using _01.Vehicles.Models.Interface;
using _02.VehiclesExtension.Factory.Interface;
using _02.VehiclesExtension.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension.Factory;

public class VehicleFactory : IVehicleFactory
{
    public IVehicle CreateVehicle(string[] vehicle)
    {
        string type = vehicle[0];
        double fuelQuantity = double.Parse(vehicle[1]);
        double fuelConsumption = double.Parse(vehicle[2]);
        double tankCapacity = double.Parse(vehicle[3]);

        if (fuelQuantity > tankCapacity)
        {
            fuelQuantity = 0;
        }

        switch (type)
        {
            case "Car":
                return new Car(fuelQuantity, fuelConsumption, tankCapacity);
            case "Truck":
                return new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            case "Bus":
                return new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            default:
                throw new ArgumentException("Invalid vehicle type");    
        }
    }
}
