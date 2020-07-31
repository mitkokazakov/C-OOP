using System;
using System.Collections.Generic;
using System.Text;
using PizzaCalories.Models;

namespace PizzaCalories
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] pizzaInfo = Console.ReadLine().Split();
            string pizzaName = pizzaInfo[1];


            string[] doughInfo = Console.ReadLine().Split();
            string flourType = doughInfo[1];
            string bakingType = doughInfo[2];
            double weight = double.Parse(doughInfo[3]);

            Dough dough = new Dough(flourType, bakingType, weight);
            Pizza pizza = new Pizza(pizzaName,dough);

            string toppingInfo = Console.ReadLine();

            while (toppingInfo != "END")
            {
                string[] toppingData = toppingInfo.Split();
                string toppingType = toppingData[1];
                double toppingWeight = double.Parse(toppingData[2]);

                Topping topping = new Topping(toppingType,toppingWeight);
                pizza.AddTopping(topping);

                toppingInfo = Console.ReadLine();
            }

            Console.WriteLine(pizza);
        }
    }
}
