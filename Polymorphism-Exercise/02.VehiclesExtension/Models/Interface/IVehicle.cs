using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles.Models.Interface;

public interface IVehicle
{
    double FuelQuantity { get; }
    double FuelConsumption { get; }

    double TankCapacity { get; }

    string Drive(double distance, bool isEmpty);

    void Refuel(double amount);
}
