using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animal
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{base.Name}, {base.Weight}, {this.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
