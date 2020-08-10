using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double ConsumptionPerKilometer { get; }

        string Drive(double kilometers);
        void Refuel(double fuelAmount);
    }
}
