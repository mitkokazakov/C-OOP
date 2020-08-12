using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Mouse : Mammal
    {
        public const double MOUSE_MULT = 0.1;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {

        }

        public override double WeightMultiply => MOUSE_MULT;

        public override ICollection<Type> PreferedFood => new List<Type>
        {
            typeof(Vegetable),
            typeof(Fruit)
        };

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
