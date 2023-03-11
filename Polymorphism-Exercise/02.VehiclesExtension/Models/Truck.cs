using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension.Models;

public class Truck : Vehicle
{
    private const double TruckIncreasedConsumption = 1.6;

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
        : base(fuelQuantity, fuelConsumption, TruckIncreasedConsumption, tankCapacity)
    {
    }

    //public override void Refuel(double amount)
    //{
    //    base.Refuel(amount * 0.95);
    //}
}
