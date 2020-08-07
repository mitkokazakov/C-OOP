using Military.Contracts;
using Military.Exceptions;
using Military.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Military.Core
{
    public class Engine
    {
        private ICollection<ISoldier> soldiers;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] soldiersInfo = input.Split();
                string soldierType = soldiersInfo[0];
                string id = soldiersInfo[1];
                string firstName = soldiersInfo[2];
                string lastName = soldiersInfo[3];

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(soldiersInfo[4]);

                    IPrivate privateToAdd = new Private(id, firstName, lastName, salary);
                    this.soldiers.Add(privateToAdd);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(soldiersInfo[4]);
                    var currentPrivates = soldiersInfo.Skip(5);

                    ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                    foreach (var prv in currentPrivates)
                    {
                        ISoldier foundPrivate = this.soldiers.First(p => p.Id == prv);
                        general.AddPrivates(foundPrivate);
                    }

                    this.soldiers.Add(general);

                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(soldiersInfo[4]);
                    string corps = soldiersInfo[5];

                    try
                    {
                        Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                        string[] repairs = soldiersInfo.Skip(6).ToArray();

                        for (int i = 0; i < repairs.Length; i += 2)
                        {
                            string partName = repairs[i];
                            int hoursWorked = int.Parse(repairs[i + 1]);

                            Repair repair = new Repair(partName, hoursWorked);

                            engineer.AddRepair(repair);
                        }

                        this.soldiers.Add(engineer);
                    }
                    catch (InvalidCorpsException ex)
                    {

                        continue;
                    }
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(soldiersInfo[4]);
                    string corps = soldiersInfo[5];

                    try
                    {
                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                        string[] missions = soldiersInfo.Skip(6).ToArray();

                        for (int i = 0; i < missions.Length; i += 2)
                        {
                            string codeName = missions[i];
                            string state = missions[i + 1];

                            try
                            {
                                IMission mission = new Mission(codeName, state);
                                commando.AddMission(mission);
                            }
                            catch (Exception ex)
                            {

                                continue;
                            }
                            

                        }

                        this.soldiers.Add(commando);
                    }
                    catch (Exception ex)
                    {

                        continue;
                    }
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(soldiersInfo[4]);

                    ISpy spy = new Spy(id,firstName,lastName,codeNumber);

                    this.soldiers.Add(spy);
                }

                input = Console.ReadLine();
            }

            foreach (var soldier in this.soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
