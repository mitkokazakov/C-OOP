

using FootballTeamGenerator.Common;
using FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace FootballTeamGenerator
{
    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }
        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputInfo = input.Split(";",StringSplitOptions.None);
                string mainCommand = inputInfo[0];

                try
                {
                    if (mainCommand == "Team")
                    {
                        string teamName = inputInfo[1];

                        Team team = new Team(teamName);
                        this.teams.Add(team);
                    }
                    else if (mainCommand == "Add")
                    {
                        string teamName = inputInfo[1];
                        string playerName = inputInfo[2];
                        int endurance = int.Parse(inputInfo[3]);
                        int sprint = int.Parse(inputInfo[4]);
                        int dribble = int.Parse(inputInfo[5]);
                        int passing = int.Parse(inputInfo[6]);
                        int shooting = int.Parse(inputInfo[7]);

                        ValidateTeam(teamName);

                        Team currentTeam = this.teams.First(t => t.Name == teamName);

                        Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
                        Player player = new Player(playerName, stats);
                        currentTeam.AddPlayer(player);
                    }
                    else if (mainCommand == "Remove")
                    {
                        string teamName = inputInfo[1];
                        string playerName = inputInfo[2];

                        ValidateTeam(teamName);

                        Team currentTeam = this.teams.First(t => t.Name == teamName);

                        currentTeam.RemovePlayer(playerName);
                    }
                    else if (mainCommand == "Rating")
                    {
                        string teamName = inputInfo[1];

                        ValidateTeam(teamName);

                        Team targetTeam = this.teams.First(t => t.Name == teamName);
                        Console.WriteLine(targetTeam);
                    }

                    
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                input = Console.ReadLine();
            }
        }

        private void ValidateTeam(string teamName)
        {
            if (!this.teams.Any(t => t.Name == teamName))
            {
                throw new ArgumentException(String.Format(ErrorMessages.MissingTeam, teamName));
            }
        }
    }
}
