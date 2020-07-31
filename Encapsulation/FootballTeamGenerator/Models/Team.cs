using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;

        private Team()
        {
            this.players = new List<Player>();
        }

        public Team(string name) : this()
        {
            this.Name = name;
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

        public int Rating
        {
            get 
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }

                return (int)Math.Round(this.players.Sum(p => p.OverralSkills) / this.players.Count);
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            
            if (!this.players.Any(p => p.Name == playerName))
            {
                throw new ArgumentException(String.Format(ErrorMessages.MissingPlayer,playerName,this.Name));
            }

            Player playerToremove = this.players.First(p => p.Name == playerName);

            this.players.Remove(playerToremove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
