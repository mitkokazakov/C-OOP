using FoodShortage.Contracts;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodShortage.Core
{
    public class Engine
    {
        private List<IBuyer> buyers;

        public Engine()
        {
            this.buyers = new List<IBuyer>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];

                    IBuyer citizen = new Citizen(name,age,id,birthdate);
                    this.buyers.Add(citizen);
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    IBuyer rebel = new Rebel(name,age,group);
                    this.buyers.Add(rebel);
                }
            }

            string buyersName = Console.ReadLine();

            while (buyersName != "End")
            {
                var existBuyer = this.buyers.Find(b => b.Name == buyersName);

                if (existBuyer != null)
                {
                    existBuyer.BuyFood();
                }

                buyersName = Console.ReadLine();
            }

            int totalFoodPurchased = this.buyers.Sum(b => b.Food);

            Console.WriteLine(totalFoodPurchased);
        }
    }
}
