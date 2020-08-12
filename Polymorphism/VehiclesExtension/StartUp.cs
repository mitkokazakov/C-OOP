using System;
using VehiclesExtension.Core;

namespace VehiclesExtension
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
