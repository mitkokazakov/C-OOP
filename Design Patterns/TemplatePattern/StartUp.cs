using System;

namespace TemplatePattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            TwelveGrain twelveGrain = new TwelveGrain();
            Sourdough sourdough = new Sourdough();
            WholeWheat wholeWheat = new WholeWheat();

            twelveGrain.Make();

            Console.WriteLine();

            sourdough.Make();

            Console.WriteLine();

            wholeWheat.Make();
        }
    }
}
