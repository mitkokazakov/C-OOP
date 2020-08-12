using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public class Hen : Bird
    {
        public const double HEN_MULT = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {

        }

        public override double WeightMultiply => HEN_MULT;

        public override ICollection<Type> PreferedFood => new List<Type>
        {
            typeof(Vegetable),
            typeof(Fruit),
            typeof(Meat),
            typeof(Seeds)
        };

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
