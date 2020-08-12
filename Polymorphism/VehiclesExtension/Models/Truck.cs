using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double CONSUMPT_INCREASE = 1.6;

        public Truck(double fuelQty, double consumption, double capacity) : base(fuelQty, consumption,capacity)
        {

        }

        public override double ConsumptionPerKilometer
        {
            get
            {
                return base.ConsumptionPerKilometer;
            }
            protected set
            {
                base.ConsumptionPerKilometer = value + CONSUMPT_INCREASE;
            }
        }

        public override string Drive(double kilometers)
        {
            double fuelNeeded = base.ConsumptionPerKilometer * kilometers;

            if (fuelNeeded <= base.FuelQuantity)
            {
                base.FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {kilometers} km";
            }
            else
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }
        }

        public override void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }
            if (this.FuelQuantity + fuelAmount > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {fuelAmount} fuel in the tank");
            }

            base.FuelQuantity += fuelAmount * 0.95;
        }

        public override string ToString()
        {
            return $"Truck: {base.FuelQuantity:f2}";
        }
    }
}
