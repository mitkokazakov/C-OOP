using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Cat : Feline
    {
        public const double CAT_MULT = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {

        }

        public override double WeightMultiply => CAT_MULT;

        public override ICollection<Type> PreferedFood => new List<Type>
        {
            typeof(Vegetable),
            typeof(Meat)
        };

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
