using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animal;
using WildFarm.Models.Contracts;
using WildFarm.Models.Food;

namespace WildFarm.Core
{
    public class Engine
    {
        private ICollection<IAnimal> animals;

        public Engine()
        {
            this.animals = new List<IAnimal>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] animalInfo = input.Split();
                string[] foodInfo = Console.ReadLine().Split();

                string foodType = foodInfo[0];
                int foodQuantity = int.Parse(foodInfo[1]);

                string animalType = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                IAnimal animal = null;

                if (animalType == "Owl")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    animal = new Owl(name,weight,wingSize);
                }
                else if (animalType == "Hen")
                {
                    double wingSize = double.Parse(animalInfo[3]);
                    animal = new Hen(name, weight, wingSize);
                }
                else if (animalType == "Mouse")
                {
                    string livingRegion = animalInfo[3];
                    animal = new Mouse(name,weight,livingRegion);
                }
                else if (animalType == "Dog")
                {
                    string livingRegion = animalInfo[3];
                    animal = new Dog(name, weight, livingRegion);
                }
                else if (animalType == "Cat")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else if (animalType == "Tiger")
                {
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                }

                IFood food = null;

                if (foodType == "Vegetable")
                {
                    food = new Vegetable(foodQuantity);
                }
                else if (foodType == "Fruit")
                {
                    food = new Fruit(foodQuantity);
                }
                else if (foodType == "Meat")
                {
                    food = new Meat(foodQuantity);
                }
                else if (foodType == "Seeds")
                {
                    food = new Seeds(foodQuantity);
                }

                this.animals.Add(animal);
                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Feed(food);
                    
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    
                }

                input = Console.ReadLine();
            }

            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
