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
        private readonly List<IIdentity> ids;


        public Engine()
        {
            this.ids = new List<IIdentity>();
        }

        public void Run()
        {
            ProccesInput();

            string lastDigits = Console.ReadLine();

            

            PrintFakeRobotsAndCitizens(lastDigits);
        }

        private void PrintFakeRobotsAndCitizens(string lastDigits)
        {
            foreach (var rc in this.ids.Where(rc => rc.Id.EndsWith(lastDigits)))
            {
                Console.WriteLine(rc);
            }
        }

        

        private void ProccesInput()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputInfo = input.Split();

                if (inputInfo.Length == 3)
                {
                    string name = inputInfo[0];
                    int age = int.Parse(inputInfo[1]);
                    string id = inputInfo[2];

                    ICitizen citizen = new Citizen(name, age, id);
                    this.ids.Add(citizen);

                }
                else if (inputInfo.Length == 2)
                {
                    string model = inputInfo[0];
                    string id = inputInfo[1];

                    IRobot robot = new Robot(model, id);
                    this.ids.Add(robot);
                }

                input = Console.ReadLine();
            }
        }
    }
}
