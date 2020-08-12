using System;


namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double CONSUMPT_INCREASE = 0.9;

        public Car(double fuelQty, double consumption, double capacity) : base(fuelQty, consumption, capacity)
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
            base.FuelQuantity += fuelAmount;
        }

        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:f2}";
        }
    }
}
