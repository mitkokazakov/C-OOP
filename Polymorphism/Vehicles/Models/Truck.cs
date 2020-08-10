using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double CONSUMPT_INCREASE = 1.6;

        public Truck(double fuelQty, double consumption) : base(fuelQty, consumption)
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
            double fuelNeeded = this.ConsumptionPerKilometer * kilometers;

            if (fuelNeeded <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {kilometers} km";
            }
            else
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }
        }

        public override void Refuel(double fuelAmount)
        {
            this.FuelQuantity += fuelAmount * 0.95;
        }

        public override string ToString()
        {
            return $"Truck: {this.FuelQuantity:f2}";
        }
    }
}
