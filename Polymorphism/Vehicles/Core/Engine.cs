using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {

            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();

            double carFuelQty = double.Parse(carInfo[1]);
            double carLitersPerKm = double.Parse(carInfo[2]);

            IVehicle car = new Car(carFuelQty, carLitersPerKm);

            double truckFuelQty = double.Parse(truckInfo[1]);
            double truckLitersPerKm = double.Parse(truckInfo[2]);

            IVehicle truck = new Truck(truckFuelQty, truckLitersPerKm);


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandInfo = Console.ReadLine().Split();
                string mainCommand = commandInfo[0];
                string typeVehicle = commandInfo[1];

                if (mainCommand == "Drive")
                {
                    double kilometers = double.Parse(commandInfo[2]);

                    if (typeVehicle == "Car")
                    {
                        try
                        {
                            Console.WriteLine(car.Drive(kilometers)); ;
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (typeVehicle == "Truck")
                    {
                        try
                        {
                            Console.WriteLine(truck.Drive(kilometers)); ;
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else if (mainCommand == "Refuel")
                {
                    double liters = double.Parse(commandInfo[2]);

                    if (typeVehicle == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else if (typeVehicle == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
