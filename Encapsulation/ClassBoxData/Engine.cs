using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            

            try
            {
                Box box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurafceArea():f2}");
                Console.WriteLine($"Volume - {box.Volume():f2}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
