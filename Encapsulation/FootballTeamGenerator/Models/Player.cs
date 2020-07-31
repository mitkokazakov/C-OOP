using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;
        private Stats stats;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get 
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.InvalidName);
                }

                this.name = value;
            }
        }

        public Stats Stats { get; }

        public double OverralSkills => this.Stats.AverageStats;
    }
}
