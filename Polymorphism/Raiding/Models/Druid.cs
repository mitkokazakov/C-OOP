using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DRUID_POWER = 80;

        public Druid(string name) : base(name, DRUID_POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {base.Name} healed for {DRUID_POWER}";
        }
    }
}
