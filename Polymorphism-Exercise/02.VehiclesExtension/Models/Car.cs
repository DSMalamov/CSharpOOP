using _01.Vehicles.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension.Models;

public class Car : Vehicle
{
    private const double CarIncreasedConsumption = 0.9;

    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
        : base(fuelQuantity, fuelConsumption, CarIncreasedConsumption, tankCapacity)
    {
    }
}
