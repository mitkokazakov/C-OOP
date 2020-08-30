using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO;
using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IManagerController managerController;
        private IWriter writter;
        private IReader reader;

        public Engine()
        {
            this.managerController = new ManagerController();
            this.writter = new Writter();
            this.reader = new Reader();
        }

        public void Run()
        {
            while(true)
            {
                string input = reader.ReadLine();

                string[] inputInfo = input.Split();

                string mainCommand = inputInfo[0];

                string result = String.Empty;

                if (mainCommand == "Exit")
                {
                    Environment.Exit(0);
                }


                try
                {
                    if (mainCommand == "AddPlayer")
                    {
                        string playerType = inputInfo[1];
                        string playerUsername = inputInfo[2];

                        result = this.managerController.AddPlayer(playerType, playerUsername);
                    }
                    else if (mainCommand == "AddCard")
                    {
                        string cardType = inputInfo[1];
                        string cardName = inputInfo[2];

                        result = this.managerController.AddCard(cardType, cardName);
                    }
                    else if (mainCommand == "AddPlayerCard")
                    {
                        string username = inputInfo[1];
                        string cardName = inputInfo[2];

                        result = this.managerController.AddPlayerCard(username, cardName);
                    }
                    else if (mainCommand == "Fight")
                    {
                        string attackerUsername = inputInfo[1];
                        string enemyUsername = inputInfo[2];

                        result = this.managerController.Fight(attackerUsername, enemyUsername);
                    }
                    else if (mainCommand == "Report")
                    {
                        result = this.managerController.Report();
                    }

                    this.writter.WriteLine(result);
                }
                catch (Exception ex)
                {

                    this.writter.WriteLine(ex.Message);
                }

            }
        }
    }
}
