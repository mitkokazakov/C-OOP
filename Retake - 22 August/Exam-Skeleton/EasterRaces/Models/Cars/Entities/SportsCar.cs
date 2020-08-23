using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double CubicCentimeters = 3000;
        private const int MinPower = 250;
        private const int MaxPower = 450;

        public SportsCar(string model, int horsePower) : base(model, horsePower, CubicCentimeters, MinPower, MaxPower)
        {

        }
    }
}
