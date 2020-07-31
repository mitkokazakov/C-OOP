using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Common
{
    public static class ErrorMessages
    {
        public static string InvalidTypeDough = "Invalid type of dough.";
        public static string InvalidRangeForWeight = "Dough weight should be in the range [1..200].";
        public static string InvalidToppingType = "Cannot place {0} on top of your pizza.";
        public static string InvalidRangeForTopping = "{0} weight should be in the range [1..50].";
        public static string InvalidName = "Pizza name should be between 1 and 15 symbols.";
        public static string InvalidNumberOfTopping = "Number of toppings should be in range [0..10].";
    }
}
