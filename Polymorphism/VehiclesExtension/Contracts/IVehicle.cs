using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double ConsumptionPerKilometer { get; }
        double TankCapacity { get; }

        string Drive(double kilometers);
        void Refuel(double fuelAmount);
    }
}
