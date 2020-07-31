using PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private string Type
        {
            
            set
            {
                if (!IngredientHelper.ExistTopping(value))
                {
                    throw new ArgumentException(String.Format(ErrorMessages.InvalidToppingType,value));
                }

                this.type = value;
            }

        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < 0 || value > 50)
                {
                    throw new ArgumentException(String.Format(ErrorMessages.InvalidRangeForTopping,this.type));
                }

                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double calories = GlobalConstants.CaloriesPerGram * this.Weight * IngredientHelper.GetToppingModifier(this.type);
            return calories;
        }
    }
}
