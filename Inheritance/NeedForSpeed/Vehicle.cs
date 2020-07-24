﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public void Drive(double kilometers)
        {
            if (kilometers * this.FuelConsumption <= this.Fuel)
            {
                this.Fuel -= kilometers * this.FuelConsumption;
            }
            
        }
    }
}
