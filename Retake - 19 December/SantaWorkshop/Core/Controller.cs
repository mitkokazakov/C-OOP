using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Repositories.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private IRepository<IDwarf> dwarfs;
        private IRepository<IPresent> presents;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf;

            if (dwarfType == nameof(HappyDwarf))
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType == nameof(SleepyDwarf))
            {
                dwarf = new SleepyDwarf(dwarfName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            this.dwarfs.Add(dwarf);

            string reslut = String.Format(OutputMessages.DwarfAdded,dwarfType,dwarfName);

            return reslut;
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf dwarf = this.dwarfs.FindByName(dwarfName);

            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            IInstrument instrument = new Instrument(power);

            dwarf.AddInstrument(instrument);

            string reslut = String.Format(OutputMessages.InstrumentAdded, power, dwarfName);

            return reslut;
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName,energyRequired);

            this.presents.Add(present);

            string reslut = String.Format(OutputMessages.PresentAdded, presentName);

            return reslut;
        }

        public string CraftPresent(string presentName)
        {
            List<IDwarf> bestDwarfs = this.dwarfs.Models.Where(d => d.Energy >= 50).OrderByDescending(d => d.Energy).ToList();

            Workshop workshop = new Workshop();

            IPresent present = this.presents.FindByName(presentName);

            if (!bestDwarfs.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            foreach (var dwarf in bestDwarfs)
            {
                if (dwarf.Energy <= 0)
                {
                    this.dwarfs.Remove(dwarf);
                    continue;
                }

                workshop.Craft(present,dwarf);
            }

            string result = present.IsDone() ? String.Format(OutputMessages.PresentIsDone,presentName) : String.Format(OutputMessages.PresentIsNotDone,presentName);
            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.presents.Models.Where(p => p.IsDone()).Count()} presents are done!");
            sb.AppendLine("Dwarfs info:");

            foreach (var dwarf in this.dwarfs.Models)
            {
                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments: {dwarf.Instruments.Where(i => i.IsBroken() == false).Count()} not broken left");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
