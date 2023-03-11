using _01.Vehicles.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension.Models;

public class Vehicle : IVehicle
{
    private double carIncreasedConsumption;
 
    public Vehicle(double fuelQuantity, double fuelConsumption, double increasedConsumption, double tankCapacity)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
        IncreasedConsumption = increasedConsumption;
        TankCapacity = tankCapacity;
    }

    public double FuelQuantity { get; private set; }

    public double FuelConsumption { get; private set; }

    public double IncreasedConsumption { get; private set; }

    public double TankCapacity { get; private set; }

    public string Drive(double distance, bool IsEmpty)
    {

        double consumption;

        if (IsEmpty)
        {
            consumption = FuelConsumption * distance;
            
        }
        else
        {
            consumption = (FuelConsumption + IncreasedConsumption) * distance;
        }
        

        if (FuelQuantity < consumption)
        {
            throw new ArgumentException($"{GetType().Name} needs refueling");
        }

        FuelQuantity -= consumption;

        return $"{GetType().Name} travelled {distance} km";
    }

    public virtual void Refuel(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        if (amount + FuelQuantity > TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
        }

        FuelQuantity += amount;
    }

    public override string ToString()
    {
        return $"{GetType().Name}: {FuelQuantity:f2}";
    }
}
