using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles.Models;

public class Truck : Vehicle
{
    private const double IncreasedConsumprion = 1.6;
    public Truck(double fuelQuantity, double fuelConsumption) 
        : base(fuelQuantity, fuelConsumption, IncreasedConsumprion)
    {
    }

    public override void Refuel(double amount)
    {
        base.Refuel(amount * 0.95);
    }
}
