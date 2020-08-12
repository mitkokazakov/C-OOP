using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animal
{
    public abstract class Bird : Animal
    {
        
        public Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; protected set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{base.Name}, {this.WingSize}, {base.Weight}, {base.FoodEaten}]";
        }

    }
}
