using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Exceptions;
using WildFarm.Models.Contracts;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animal
{
    public abstract class Animal : IAnimal
    {
        private const string INVALID_FOOD_MSG = "{0} does not eat {1}!";

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightMultiply { get; }
        public abstract ICollection<Type> PreferedFood { get; }

        public void Feed(IFood food)
        {
            if (!this.PreferedFood.Contains(food.GetType()))
            {
                throw new InvalidFood(String.Format(INVALID_FOOD_MSG,this.GetType().Name,food.GetType().Name));
            }

            this.FoodEaten += food.Quantity;
            this.Weight += this.WeightMultiply * food.Quantity;
        }

        public abstract string ProduceSound();

        

    }
}
