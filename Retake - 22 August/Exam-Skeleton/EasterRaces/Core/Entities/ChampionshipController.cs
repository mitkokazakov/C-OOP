using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<ICar> cars;
        private IRepository<IDriver> drivers;
        private IRepository<IRace> races;

        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.drivers.GetByName(driverName);
            ICar car = this.cars.GetByName(carModel);

            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound,driverName));
            }
            if (car == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            string result = String.Format(OutputMessages.CarAdded,driverName,carModel);
            return result;
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IDriver driver = this.drivers.GetByName(driverName);
            IRace race = this.races.GetByName(raceName);

            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            race.AddDriver(driver);

            string result = String.Format(OutputMessages.DriverAdded,driverName,raceName);
            return result;
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model,horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model,horsePower);
            }

            var existed = this.cars.GetByName(model);

            if (existed != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarExists,model));
            }

            this.cars.Add(car);

            string result = $"{car.GetType().Name} {model} is created.";
            return result;
        }

        public string CreateDriver(string driverName)
        {
            IDriver driver = new Driver(driverName);

            IDriver existed = this.drivers.GetByName(driverName);

            if (existed != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriversExists,driverName));
            }

            this.drivers.Add(driver);

            string result = String.Format(OutputMessages.DriverCreated,driverName);

            return result;
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name,laps);

            var existed = this.races.GetByName(name);

            if (existed != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists,name));
            }

            this.races.Add(race);

            string result = String.Format(OutputMessages.RaceCreated,name);
            return result;
        }

        public string StartRace(string raceName)
        {
            IRace race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound,raceName));
            }

            var allDrivers = race.Drivers;

            if (allDrivers.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            allDrivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps));

            StringBuilder sb = new StringBuilder();

            var bestDrivers = allDrivers.Take(3);

            int counter = 0;

            foreach (var driver in bestDrivers)
            {
                counter++;

                if (counter == 1)
                {
                    sb.AppendLine($"Driver {driver.Name} wins {raceName} race.");
                }
                else if (counter == 2)
                {
                    sb.AppendLine($"Driver {driver.Name} is second in {raceName} race.");
                }
                else if (counter == 3)
                {
                    sb.AppendLine($"Driver {driver.Name} is third in {raceName} race.");
                }

            }

            this.races.Remove(race);

            return sb.ToString().TrimEnd();
            


        }
    }
}
