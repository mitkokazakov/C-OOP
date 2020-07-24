

using System;
using System.Collections.Generic;

namespace Animals
{
    public class Engine
    {
        private List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }
        public void Run()
        {
            string type = Console.ReadLine();

            while (type != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split();

                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);

                Animal animal = null;

                if (type == "Dog")
                {
                    
                    try
                    {
                        animal = new Dog(name, age, animalInfo[2]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (type == "Cat")
                {
                    try
                    {
                        animal = new Cat(name, age, animalInfo[2]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (type == "Frog")
                {
                    try
                    {
                        animal = new Frog(name, age, animalInfo[2]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (type == "Kitten")
                {
                    try
                    {
                        animal = new Kitten(name, age);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (type == "Tomcat")
                {
                    try
                    {
                        animal = new Tomcat(name, age);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.animals.Add(animal);

                type = Console.ReadLine();
            }

            foreach (Animal animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
