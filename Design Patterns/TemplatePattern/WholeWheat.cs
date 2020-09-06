using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Whole Wheat Bread. (15 minutes)");
        }

        public override void MixIngridients()
        {
            Console.WriteLine("Gathering Ingridients  for Whole Wheat Bread.");
        }
    }
}
