using BorderControl.Contracts;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl.Core
{
    public class Engine
    {
        private readonly List<IBirthable> birthables;


        public Engine()
        {
            this.birthables = new List<IBirthable>();
        }

        public void Run()
        {
            ProccesInput();

            string year = Console.ReadLine();

            var filteredPetsAndCitizens = this.birthables.Where(x => x.Birthdate.EndsWith(year));

            if (filteredPetsAndCitizens.Count() == 0)
            {
                Console.WriteLine();
            }
            else
            {
                foreach (var item in filteredPetsAndCitizens)
                {
                    Console.WriteLine(item);
                }
            }
        }

        

        private void ProccesInput()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputInfo = input.Split();

                if (inputInfo[0] == "Citizen")
                {
                    string name = inputInfo[1];
                    int age = int.Parse(inputInfo[2]);
                    string id = inputInfo[3];
                    string birthdate = inputInfo[4];
                    ICitizen citizen = new Citizen(name, age, id,birthdate);
                    this.birthables.Add(citizen);

                }
                else if (inputInfo[0] == "Pet")
                {
                    string petName = inputInfo[1];
                    string birthdate = inputInfo[2];

                    Pet pet = new Pet(petName,birthdate);
                    this.birthables.Add(pet);
                }

                input = Console.ReadLine();
            }
        }
    }
}
