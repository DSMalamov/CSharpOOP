using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles.Models;

public class Car : Vehicle
{
    private const double IncreasedConsumprion = 0.9;
    public Car(double fuelQuantity, double fuelConsumption) 
        : base(fuelQuantity, fuelConsumption, IncreasedConsumprion)
    {
    }


}
