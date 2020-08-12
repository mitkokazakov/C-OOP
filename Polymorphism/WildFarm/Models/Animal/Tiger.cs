using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Tiger : Feline
    {
        public const double TIGER_MULT = 1.0;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {

        }

        public override double WeightMultiply => TIGER_MULT;

        public override ICollection<Type> PreferedFood => new List<Type>
        {
            typeof(Meat)
        };

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
