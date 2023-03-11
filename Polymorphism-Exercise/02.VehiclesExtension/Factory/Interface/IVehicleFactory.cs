using _01.Vehicles.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension.Factory.Interface;

public interface IVehicleFactory
{
    IVehicle CreateVehicle(string[] vehicle);
}
