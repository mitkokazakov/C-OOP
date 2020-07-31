using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Common
{
    public static class IngredientHelper
    {
        public static readonly Dictionary<string, double> DoughModifiers = new Dictionary<string, double>
        {
            {"white", 1.5},
            {"wholegrain", 1.0},
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 }
        };



        public static readonly Dictionary<string, double> ToppingsModifiers = new Dictionary<string, double>
        {
            {"meat", 1.2},
            {"veggies", 0.8},
            {"cheese", 1.1 },
            {"sauce", 0.9 }
        };

        public static double GetDoughModifier(string typeDough)
        {
            double valueModifier = DoughModifiers[typeDough.ToLower()];
            return valueModifier;
        }

        public static bool ExistDough(string type)
        {
            if (DoughModifiers.ContainsKey(type.ToLower()))
            {
                return true;
            }

            return false;
        }

        public static double GetToppingModifier(string typeTopping)
        {
            double toppingModifier = ToppingsModifiers[typeTopping.ToLower()];
            return toppingModifier;
        }

        public static bool ExistTopping(string type)
        {
            if (ToppingsModifiers.ContainsKey(type.ToLower()))
            {
                return true;
            }

            return false;
        }

    }
}
