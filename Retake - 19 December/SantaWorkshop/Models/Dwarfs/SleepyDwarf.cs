using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    class SleepyDwarf : Dwarf
    {
        private const int SleepyDwarfEnergy = 50;

        public SleepyDwarf(string name) : base(name, SleepyDwarfEnergy)
        {
        }

        public override void Work()
        {
            this.Energy -= 15;
        }
    }
}
