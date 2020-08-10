using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        public Vehicle(double fuelQty, double consumption)
        {
            this.FuelQuantity = fuelQty;
            this.ConsumptionPerKilometer = consumption;
        }

        public double FuelQuantity { get; protected set; }

        public virtual double ConsumptionPerKilometer { get; protected set; }

        public abstract string Drive(double kilometers);


        public abstract void Refuel(double fuelAmount);
        
    }
}
