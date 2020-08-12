using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Dog : Mammal
    {
        public const double DOG_MULT = 0.4;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {

        }

        public override double WeightMultiply => DOG_MULT;

        public override ICollection<Type> PreferedFood => new List<Type>
        {
            typeof(Meat)
        };

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
