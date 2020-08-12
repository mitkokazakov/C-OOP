using System;
using System.Collections.Generic;
using System.Text;
using VehiclesExtension.Contracts;

namespace VehiclesExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQty;
        private double consumption;
        private double capacity;

        public Vehicle(double fuelQty, double consumption, double capacity)
        {

            this.ConsumptionPerKilometer = consumption;
            this.TankCapacity = capacity;
            this.FuelQuantity = fuelQty;
        }


        public double FuelQuantity
        {
            get
            {
                return this.fuelQty;
            }
            protected set
            {
                if (value > this.capacity)
                {
                    this.fuelQty = 0;
                }
                else
                {
                    this.fuelQty = value;
                }

            }
        }

        public virtual double ConsumptionPerKilometer
        {
            get
            {
                return this.consumption;
            }
            protected set
            {
                this.consumption = value;
            }
        }

        public double TankCapacity
        {
            get
            {
                return this.capacity;
            }
            protected set
            {
                this.capacity = value;
            }
        }

        public abstract string Drive(double kilometers);


        public abstract void Refuel(double fuelAmount);
        
        
    }
}
