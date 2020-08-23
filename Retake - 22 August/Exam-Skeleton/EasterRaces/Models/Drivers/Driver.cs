using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers
{
    class Driver : IDriver
    {
        private string name;

        public Driver(string name)
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
                if (String.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName,value,5));
                }

                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Car == null ? false : true;

        public void AddCar(ICar car)
        {
            if (car != null)
            {
                this.Car = car;
            }
            else
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
