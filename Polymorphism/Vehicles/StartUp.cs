using System;
using Vehicles.Core;

namespace Vehicles
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
