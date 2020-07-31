using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Stats
    {
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;
        private const double COUNT_STAT = 5.0;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                ValidateStats(value,nameof(this.Endurance));

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                ValidateStats(value, nameof(this.Sprint));

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                ValidateStats(value, nameof(this.Dribble));

                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                ValidateStats(value, nameof(this.Passing));

                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                ValidateStats(value, nameof(this.Shooting));

                this.shooting = value;
            }
        }

        public double AverageStats => (this.Endurance + this.Dribble + this.Passing + this.Shooting + this.Sprint) / COUNT_STAT;
        

        private void ValidateStats(int value, string typeStat)
        {
            if (value < MIN_VALUE || value > MAX_VALUE)
            {
                throw new ArgumentException(String.Format(ErrorMessages.InvalidStatRange, typeStat));
            }
        }
    }
}
