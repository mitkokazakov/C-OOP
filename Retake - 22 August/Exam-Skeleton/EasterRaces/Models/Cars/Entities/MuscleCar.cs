﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double CubicCentimeters = 5000;
        private const int MinPower = 400;
        private const int MaxPower = 600;
        public MuscleCar(string model, int horsePower) : base(model, horsePower, CubicCentimeters, MinPower, MaxPower)
        {

        }
    }
}
