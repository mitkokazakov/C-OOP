﻿

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double cakeGrams = 250;
        private const double cakeCalories = 1000;
        private const decimal cakePrice = 5m;

        public Cake(string name) : base(name, cakePrice, cakeGrams, cakeCalories)
        {

        }
    }
}
