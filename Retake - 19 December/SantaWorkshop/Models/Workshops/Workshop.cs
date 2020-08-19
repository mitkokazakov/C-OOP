using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
                
        }

        public void Craft(IPresent present, IDwarf dwarf)
        {
            

            while (!present.IsDone())
            {
                

                if (dwarf.Energy > 0 && dwarf.Instruments.Any(i => i.IsBroken() == false))
                {
                    IInstrument instrument = dwarf.Instruments.First(i => i.IsBroken() == false);

                    present.GetCrafted();
                    instrument.Use();
                    dwarf.Work();
                }
                else
                {
                    break;
                }
            }

            
        }
    }
}
