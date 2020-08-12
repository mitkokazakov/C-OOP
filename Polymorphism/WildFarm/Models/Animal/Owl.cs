using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Owl : Bird
    {
        private const double OWL_MULT = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {

        }

        public override double WeightMultiply => OWL_MULT;

        public override ICollection<Type> PreferedFood => new List<Type>
            {
                typeof(Meat)
            };

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
