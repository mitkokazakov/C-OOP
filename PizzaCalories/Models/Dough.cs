using PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private string flourType;
        private string bakingType;
        private double weight;

        public Dough(string flourType, string bakingType, double weight)
        {
            this.FlourType = flourType;
            this.BakingType = bakingType;
            this.Weight = weight;
        }

        private string FlourType
        {
            
            set
            {
                if (!IngredientHelper.ExistDough(value))
                {
                    throw new ArgumentException(ErrorMessages.InvalidTypeDough);
                }

                this.flourType = value;
            }
        }

        private string BakingType
        {
            
            set
            {
                if (!IngredientHelper.ExistDough(value))
                {
                    throw new ArgumentException(ErrorMessages.InvalidTypeDough);
                }

                this.bakingType = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(ErrorMessages.InvalidRangeForWeight);
                }

                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double result = GlobalConstants.CaloriesPerGram * this.Weight * IngredientHelper.GetDoughModifier(this.flourType) * IngredientHelper.GetDoughModifier(this.bakingType);
            return result;
        }
    }
}
