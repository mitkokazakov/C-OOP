using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Telephony.Exceptions;
using Telephony.Models;

namespace Telephony.Core
{
    public class Engine
    {
        public Engine()
        {

        }
        public void Run()
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            CallNumbers(phoneNumbers, stationaryPhone, smartphone);

            BrowseSites(sites, smartphone);

        }

        private static void BrowseSites(string[] sites, Smartphone smartphone)
        {
            foreach (var site in sites)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(site));
                }
                catch (InvalidURLException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
            }
        }

        private static void CallNumbers(string[] phoneNumbers, StationaryPhone stationaryPhone, Smartphone smartphone)
        {
            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(number));
                    }
                    else
                    {
                        throw new InvalidNumberException();
                    }
                }
                catch (InvalidNumberException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
            }
        }
    }
}
