using _01.Vehicles.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles.Models;

public abstract class Vehicle : IVehicle
{
    private double increasedConsumprion;
    protected Vehicle(double fuelQuantity, double fuelConsumption, double increasedConsumption)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
        this.increasedConsumprion = increasedConsumption;
    }

    public double FuelQuantity { get; private set; }

    public double FuelConsumption { get; private set; }

    public string Drive(double distance)
    {
        double consumprion = FuelConsumption + increasedConsumprion;

        if (FuelQuantity < consumprion * distance)
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }

        FuelQuantity -= consumprion * distance;

        return $"{this.GetType().Name} travelled {distance} km";
        
    }

    public virtual void Refuel(double amount)
    {
        FuelQuantity += amount;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {FuelQuantity:f2}";
        
    }
}
