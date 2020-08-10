using System;


namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double CONSUMPT_INCREASE = 0.9;

        public Car(double fuelQty, double consumption) : base(fuelQty, consumption)
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
            base.FuelQuantity += fuelAmount;
        }

        public override string ToString()
        {
            return $"Car: {this.FuelQuantity:f2}";
        }
    }
}
