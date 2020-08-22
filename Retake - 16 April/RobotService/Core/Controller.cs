using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private IRobot robot;
        private List<IProcedure> procedures;
        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new List<IProcedure>();
        }

        public string Charge(string robotName, int procedureTime)
        {
            

            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            this.robot = this.garage.Robots[robotName];

            var existProcedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "Charge");

            if (existProcedure != null)
            {
                existProcedure.DoService(robot,procedureTime);
            }
            else
            {
                IProcedure procedure = new Charge();
                procedure.DoService(robot, procedureTime);
                this.procedures.Add(procedure);
            }

            string result = String.Format(OutputMessages.ChargeProcedure, robotName);

            return result;
        }

        public string Chip(string robotName, int procedureTime)
        {
            

            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            this.robot = this.garage.Robots[robotName];

            var existProcedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "Chip");

            if (existProcedure != null)
            {
                existProcedure.DoService(robot, procedureTime);
            }
            else
            {
                IProcedure procedure = new Chip();
                procedure.DoService(robot, procedureTime);
                this.procedures.Add(procedure);
            }

            string result = String.Format(OutputMessages.ChipProcedure, robotName);

            return result;
        }

        public string History(string procedureType)
        {
            IProcedure procedure;
            string result = String.Empty;

            if (procedureType == "Charge")
            {
                procedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "Charge");
                result = procedure.History();
            }
            else if (procedureType == "Chip")
            {
                procedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "Chip");
                result = procedure.History();
            }
            else if (procedureType == "Polish")
            {
                procedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "Polish");
                result = procedure.History();
            }
            else if (procedureType == "Rest")
            {
                procedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "Rest");
                result = procedure.History();
            }
            else if (procedureType == "TechCheck")
            {
                procedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "TechCheck");
                result = procedure.History();
            }
            else if (procedureType == "Work")
            {
                procedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "Work");
                result = procedure.History();
            }

            return result;
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            
            IRobot robot;

            if (robotType == nameof(HouseholdRobot))
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == nameof(PetRobot))
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == nameof(WalkerRobot))
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            garage.Manufacture(robot);

            string result = String.Format(OutputMessages.RobotManufactured, name);

            return result;
        }

        public string Polish(string robotName, int procedureTime)
        {
            

            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            this.robot = this.garage.Robots[robotName];

            var existProcedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "Polish");

            if (existProcedure != null)
            {
                existProcedure.DoService(robot, procedureTime);
            }
            else
            {
                IProcedure procedure = new Polish();
                procedure.DoService(robot, procedureTime);
                this.procedures.Add(procedure);
            }

            string result = String.Format(OutputMessages.PolishProcedure, robotName);

            return result;
        }

        public string Rest(string robotName, int procedureTime)
        {
            

            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            this.robot = this.garage.Robots[robotName];

            

            var existProcedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "Rest");

            if (existProcedure != null)
            {
                existProcedure.DoService(robot, procedureTime);
            }
            else
            {
                IProcedure procedure = new Rest();
                procedure.DoService(robot, procedureTime);
                this.procedures.Add(procedure);
            }

            string result = String.Format(OutputMessages.RestProcedure, robotName);

            return result;
        }

        public string Sell(string robotName, string ownerName)
        {

            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            this.robot = this.garage.Robots[robotName];

            this.garage.Sell(robotName, ownerName);

            string result = this.robot.IsChipped ? String.Format(OutputMessages.SellChippedRobot, ownerName) : String.Format(OutputMessages.SellNotChippedRobot, ownerName);

            return result;
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            

            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            this.robot = this.garage.Robots[robotName];

           

            var existProcedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "TechCheck");

            if (existProcedure != null)
            {
                existProcedure.DoService(robot, procedureTime);
            }
            else
            {
                IProcedure procedure = new TechCheck();
                procedure.DoService(robot, procedureTime);
                this.procedures.Add(procedure);
            }

            string result = String.Format(OutputMessages.TechCheckProcedure, robotName);

            return result;
        }

        public string Work(string robotName, int procedureTime)
        {
            

            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            this.robot = this.garage.Robots[robotName];

           

            var existProcedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "Work");

            if (existProcedure != null)
            {
                existProcedure.DoService(robot, procedureTime);
            }
            else
            {
                IProcedure procedure = new Work();
                procedure.DoService(robot, procedureTime);
                this.procedures.Add(procedure);
            }

            string result = String.Format(OutputMessages.WorkProcedure, robotName,procedureTime);

            return result;
        }
    }
}
