using PizzaCalories.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaCalories.Models
{
    class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        private Pizza()
        {
            this.toppings = new List<Topping>();
        }

        public Pizza(string name, Dough dough) : this()
        {
            this.Name = name;
            this.Dough = dough;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 0 || value.Length > 15)
                {
                    throw new ArgumentException(ErrorMessages.InvalidName);
                }

                this.name = value;
            }
             
        }

        public Dough Dough
        {
            set
            {
                this.dough = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count > 10)
            {
                throw new ArgumentException(ErrorMessages.InvalidNumberOfTopping);
            }

            this.toppings.Add(topping);
        }

        public int NumberOfToppings => this.toppings.Count;

        public double TotalCallories => this.dough.CalculateCalories() + this.toppings.Sum(t => t.CalculateCalories());

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCallories:f2} Calories.";
        }
    }
}
