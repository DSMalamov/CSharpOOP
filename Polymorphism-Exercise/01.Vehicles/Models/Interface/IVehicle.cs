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

    string Drive(double distance);

    void Refuel(double amount);
}
