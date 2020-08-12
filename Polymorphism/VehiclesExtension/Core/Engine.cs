using System;
using System.Collections.Generic;
using System.Text;
using VehiclesExtension.Contracts;
using VehiclesExtension.Models;

namespace VehiclesExtension.Core
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
            string[] busInfo = Console.ReadLine().Split();

            double carFuelQty = double.Parse(carInfo[1]);
            double carLitersPerKm = double.Parse(carInfo[2]);
            double carCapacity = double.Parse(carInfo[3]);

            IVehicle car = new Car(carFuelQty, carLitersPerKm,carCapacity);

            double truckFuelQty = double.Parse(truckInfo[1]);
            double truckLitersPerKm = double.Parse(truckInfo[2]);
            double truckCapacity = double.Parse(truckInfo[3]);

            IVehicle truck = new Truck(truckFuelQty, truckLitersPerKm, truckCapacity);

            double busFuelQty = double.Parse(busInfo[1]);
            double busLitersPerKm = double.Parse(busInfo[2]);
            double busCapacity = double.Parse(busInfo[3]);

            Bus bus = new Bus(busFuelQty, busLitersPerKm, busCapacity);

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
                    else if (typeVehicle == "Bus")
                    {
                        try
                        {
                            Console.WriteLine(bus.Drive(kilometers)); ;
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
                        try
                        {
                            car.Refuel(liters);
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
                            truck.Refuel(liters);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        
                    }
                    else if (typeVehicle == "Bus")
                    {
                        try
                        {
                            bus.Refuel(liters);
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                        }

                    }
                }
                else if (mainCommand == "DriveEmpty")
                {
                    double kilometers = double.Parse(commandInfo[2]);

                    try
                    {
                        Console.WriteLine(bus.DriveEmpty(kilometers));
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
