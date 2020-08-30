using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        public Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCardName);
                }

                this.name = value;
            }
        }

        public int DamagePoints
        {
            get
            {
                return this.damagePoints;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCardDamagePoints);
                }

                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCardHealthPoints);
                }

                this.healthPoints = value;
            }
        }
    }
}
