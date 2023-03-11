using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension.Models;

public class Bus : Vehicle
{
    private const double BusIncreasedConsumption = 1.4;
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
        : base(fuelQuantity, fuelConsumption, BusIncreasedConsumption, tankCapacity)
    {
    }

    
}
